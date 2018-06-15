/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/8/2018 4:47 PM
================================================================*/


using DG.Tweening;
using UnityEngine;

namespace Homebrew
{
	public class BehaviorDeath : Behavior, IReceive<SignalDamage>
	{
		public void HandleSignal(SignalDamage arg)
		{
			if (actor.tags.Contain(Tag.StateDead)) return;
			if (Get<DataHealth>().HP<=0)
				GetKilled();
		}


		protected virtual void GetKilled()
		{
			
			
			actor.selfTransform.ChangeLayersRecursively("Dead");
			var rigid = Get<Rigidbody2D>();
			rigid.AddForceAtPosition(new Vector2(Get<DataMove>().face, 4) * 15, actor.selfTransform.position);
			//	rigid.constraints = RigidbodyConstraints2D.None;


			var rend = actor.selfTransform.GetChild(0).GetComponent<SpriteRenderer>();
			actor.selfTransform.GetChild(0).DORotate(new Vector3(0, 0, 640), 1);
			rend.sortingOrder = 3;
			rend.color = new Color(0.65f, 0.65f, 0.65f, 1);
			Toolbox.Get<FactoryFx>()
				.SpawnBlood(actor.selfTransform.position + new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f)));
			actor.tags.Add(Tag.StateDead);
			actor.HandleDestroyGO();
			actor.OnDisable();

			if (actor.tags.Contain(Tag.GroupEnemies))
			{
				ProcessingSignals.Default.Send(new SignalChangeScore());
				ProcessingSignals.Default.Send(new SignalKilled{tag=Tag.GroupEnemies});
			}
		}
	}
}