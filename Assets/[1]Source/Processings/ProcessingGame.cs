/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/8/2018 7:18 PM
================================================================*/


using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Homebrew
{
	public class ProcessingGame : ProcessingBase, IMustBeWipedOut, ITick
	{
		[GroupBy(Tag.GroupPlayers, Tag.StateDead)]
		private Group groupDeadPlayers;

		[GroupBy(Tag.GroupPlayers)] private Group groupPlayers;
		[GroupBy(Tag.GroupWeapon)] private Group groupWeapon;
		[GroupBy(Tag.ObjectSpawnerGuns)] private Group groupSpawnWeapon;

		private float[] spawnWait = {6f, 5f, 4f};
		private int[] spawnMobs = {4, 5, 6};
		private int wave;
		private int waveLevel;
		private bool isPlaying;

		public ProcessingGame()
		{
			groupDeadPlayers.OnGroupChanged += CheckDeath;
			groupWeapon.OnGroupChanged += CheckNoWeapon;


			var labelInsertCoin = ProcessingScene.Default.Get("obj_menu/obj_start/label_value").GetComponent<TextMeshProUGUI>();
			var col = labelInsertCoin.color;

			DOTween
				.To(() => col, x => col = x, new Color(1, 1, 1, 0), 1.0f)
				.SetLoops(-1, LoopType.Yoyo)
				.OnUpdate(() => { labelInsertCoin.color = col; })
				.SetAutoKill(false)
				.SetId("labelInsertCoin");
		}

		public void Tick()
		{
			HandleStartGame();
		}

		void CheckDeath()
		{
			Timer.Add(1.0f, () => ProcessingSceneLoad.To(0));
		}

		void CheckNoWeapon()
		{
			if (groupWeapon.length == 0)
			{
				Timer.Add(10,
					() =>
					{
						if (groupPlayers.length == 0) return;

						Toolbox.Get<FactorySpawner>().SpawnWeapon(groupSpawnWeapon.actors.ReturnRandom().selfTransform.position,
							groupPlayers.actors[0].Get<DataCurrentWeapon>().weapon);
					});
			}
		}

		void HandleSpawn()
		{
			wave++;
			if (wave % 10 == 0)
				waveLevel = Mathf.Min(waveLevel += 1, 2);

			var amount = spawnMobs[waveLevel];
			var factory = Toolbox.Get<FactorySpawner>();

			for (int i = 0; i < amount; i++)
			{
				Timer.Add(i * 0.8f, () =>
				{
					var go = factory.Spawn(0);
					go.position = Toolbox.Get<DataCryoshockGameSession>().spawners[0].selfTransform.position;
				});
			}

			Timer.Add(spawnWait[waveLevel], HandleSpawn);
		}

		void HandleSpawnPlayer()
		{
			var go = Toolbox.Get<FactorySpawner>().SpawnPlayer();
			go.position = Toolbox.Get<DataCryoshockGameSession>().spawners[0].selfTransform.position;
			go.GetComponent<Actor>().tags.Add(Tag.StateBlockMove);
			Timer.Add(0.8f, () => { go.GetComponent<Actor>().tags.Remove(Tag.StateBlockMove); });
		}

		void HandleStartGame()
		{
			if (isPlaying || !Input.GetKeyDown(KeyCode.Space)) return;
			isPlaying = true;


			var canvasGroup = ProcessingScene.Default.Get("obj_menu").GetComponent<CanvasGroup>();
			var alpha = 1f;

			DOTween
				.To(() => alpha, x => alpha = x, 0, 0.4f)
				.OnUpdate(() => { canvasGroup.alpha = alpha; });

			DOTween.TweensById("labelInsertCoin")[0].Kill();

			var labelScore = ProcessingScene.Default.Get("obj_score/label_value").GetComponent<TextMeshProUGUI>();
			var col = labelScore.color;

			DOTween
				.To(() => col, x => col = x, new Color(1, 1, 1, 1), 1.0f)
				.OnUpdate(() => { labelScore.color = col; })
				.SetDelay(1.0f);

			CheckNoWeapon();
			HandleSpawnPlayer();
			Timer.Add(4, HandleSpawn);
			Timer.Add(6, () =>
			{
				ProcessingScene.Default.Get("[SCENE]/Objects/obj_saw").gameObject.SetActive(true);	
				
			});
		 

		}
	}
}