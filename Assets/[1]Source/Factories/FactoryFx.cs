/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/8/2018 6:20 PM
================================================================*/


using DG.Tweening;
using UnityEngine;

namespace Homebrew
{
	[CreateAssetMenu(fileName = "FactoryFx", menuName = "Factories/FactoryFx")]
	public class FactoryFx : Factory
	{
		[FoldoutGroup("Setup"), SerializeField]
		private DataBloodFx dataBlood;

	 
		public void SpawnBlood(Vector3 pos)
		{
			var blood = this.Populate(Pool.Entities, dataBlood.prefab);
			blood.GetComponent<SpriteRenderer>().sprite = dataBlood.sprites.Random();
			blood.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
			blood.transform.position = new Vector3(pos.x, pos.y, -0.1f);
			blood.localScale = new Vector3(0, 0, 0);

			blood.DOScale(Random.Range(1, 2f), 0.3f).SetEase(Ease.OutSine);
			Timer.Add(Random.Range(2, 5), () =>
			{
			 
				var rend = blood.GetComponent<SpriteRenderer>();

				var a = 1.0f;
				DOTween.To(() => a, x => a = x, 0.0f, 1.0f).OnUpdate(() =>
				{
			 	
					rend.color = rend.color.SetColorAlpha(a);
				});
				Timer.Add(1.0f, () =>
				{
				 
					Toolbox.Get<ProcessingGoPool>().Despawn(Pool.Entities, blood.gameObject);
				});
			});
		}

	 
	}
}