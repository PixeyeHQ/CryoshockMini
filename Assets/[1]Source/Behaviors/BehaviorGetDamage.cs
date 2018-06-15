/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/8/2018 4:37 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class BehaviorGetDamage : Behavior, IReceive<SignalTriggerEnter>
	{
		public void HandleSignal(SignalTriggerEnter arg)
		{
			if (!arg.other.HasTag(Tag.ColliderHit)) return;
			if (actor.tags.Contain(Tag.StateGod)) return;

			// check enemy
			var otherActor = arg.other.GetComponentInParent<Actor>();
			if (otherActor != null && otherActor.tags.Contain(Tag.GroupEnemies))
			{
				otherActor.Get<BehaviorGetDamage>().HandleDamage(100);
			}

			HandleDamage(1);

			if (arg.other.HasTag(Tag.ObjectBullet))
			{
				Toolbox.Get<FactorySounds>().Spawn(Tag.SoundShootHit);
				Toolbox.Get<ProcessingGoPool>().Despawn(Pool.Projectiles, arg.other.gameObject);
			}
		}

		public void HandleDamage(int dmg)
		{
			Get<DataHealth>().HP -= dmg;
			actor.SignalDispatch(new SignalDamage());
			actor.tags.Add(Tag.StateBlockMove);
			Timer.Add(Time.DeltaTime, () => actor.tags.Remove(Tag.StateBlockMove));
		}
	}
}