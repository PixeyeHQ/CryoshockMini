/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/8/2018 1:26 PM
================================================================*/


 
namespace Homebrew
{
	public class ActorWeapon : Actor, ITick
	{
		[FoldoutGroup("Setup")] public DataCurrentWeapon dataCurrentWeapon;

		protected override void Setup()
		{
			Add(dataCurrentWeapon);
			
			Add<DataView>();
			Add<BehaviorInteract>();
			Add<DecorateInteractiveObject>();
			
			tags.Add(Tag.GroupWeapon);
			
		}

	 
		
		protected override void OnBeforeDestroy()
		{
			var dataView = Get<DataView>();
			dataView.matPropBlock.SetFloat("_BlinkAlt", 1);
			dataView.SetPropertyBlock();
			Timer.Add(0.1f, () =>
			{
				dataView.matPropBlock.SetFloat("_BlinkAlt", 0);
				dataView.SetPropertyBlock();
			});
		}

		public class BehaviorInteract : Behavior, IReceive<SignalInteract>
		{
			public void HandleSignal(SignalInteract arg)
			{
				var other = arg.other;
				var dataWeapon = other.Get<DataCurrentWeapon>();
				if (dataWeapon == null) return;
				other.SignalDispatch(new SignalChangeWeapon {blueprintWeapon = Get<DataCurrentWeapon>().weapon});
				actor.HandleDestroyGO();
				Toolbox.Get<FactorySounds>().Spawn(Tag.SoundTakeGun,1);
			}
		}
	}
}