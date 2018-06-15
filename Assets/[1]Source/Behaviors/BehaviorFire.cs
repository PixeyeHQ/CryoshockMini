/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/7/2018 1:12 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class BehaviorFire : Behavior, ITick, IReceive<SignalChangeWeapon>
	{
		[Bind] private DataCurrentWeapon dataCurrentWeapon;

		private Rigidbody2D rig;
		private Transform muzzle;
		private Transform view;
		private bool conditionReloading;
  
		
		protected override void Setup()
		{
			muzzle = Get<Transform>("view/" + dataCurrentWeapon.weapon.muzzleID);
			view = Get<Transform>("view");
			rig = Get<Rigidbody2D>();
		}

		public override void OnTick()
		{
			if (CanAct())
			{
				Handle();
			}
		}

		void Handle()
		{
			dataCurrentWeapon.weapon.Shoot(rig, view.localScale.x, muzzle);
			conditionReloading = true;
			Timer.Add(dataCurrentWeapon.weapon.reloadTime, () => conditionReloading = false);
		}

		bool CanAct()
		{
			if (!Input.GetKeyDown(KeyCode.Z)) return false;
			if (actor.tags.Contain(Tag.StateDrifting)) return false;
			if (conditionReloading) return false;
			return true;
		}

		public void HandleSignal(SignalChangeWeapon arg)
		{
			dataCurrentWeapon.weapon = arg.blueprintWeapon;
			muzzle = Get<Transform>("view/" + dataCurrentWeapon.weapon.muzzleID);
		}
		
		
		
	}
}