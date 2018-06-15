/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 9:56 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class ComponentPit : MonoCached
	{
		[SerializeField] private Animator anim;
		private SpriteRenderer spr;
		private MaterialPropertyBlock matPropBlock;
		private Timer timerDecorate;

		protected override void OnAwake()
		{
			spr = anim.GetComponent<SpriteRenderer>();
			matPropBlock = new MaterialPropertyBlock();
			spr.GetPropertyBlock(matPropBlock);
			timerDecorate = new Timer(RevertLaser, 0.75f);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			var actor = other.GetActor(Tag.ColliderInteract);
			if (actor == null) return;

			HandleEnemies(actor);
			HandlePlayers(actor);
			DecorateLaser();
		}

		void HandleEnemies(Actor a)
		{
			if (!a.tags.Contain(Tag.GroupEnemies)) return;
			var tr = Toolbox.Get<DataCryoshockGameSession>().spawners[0];
			Toolbox.Get<FactorySounds>().Spawn(Tag.SoundAlarm,1);
			a.selfTransform.position = tr.transform.position;
			a.tags.Add(Tag.StateRage);
			a.tags.Add(Tag.StateBlockMove);
			Timer.Add(0.5f, () => a.tags.Remove(Tag.StateBlockMove));
		}

		void HandlePlayers(Actor a)
		{
			if (!a.tags.Contain(Tag.GroupPlayers)) return;
			a.Get<BehaviorGetDamage>().HandleDamage(100);
		}

		void DecorateLaser()
		{
			anim.SetFloat("SPEED", 2);
			matPropBlock.SetFloat("_Blink", 1);
			spr.SetPropertyBlock(matPropBlock);
			timerDecorate.Restart();
		}

		void RevertLaser()
		{
			anim.SetFloat("SPEED", 1);
			matPropBlock.SetFloat("_Blink", 0);
			spr.SetPropertyBlock(matPropBlock);
		}
	}
}