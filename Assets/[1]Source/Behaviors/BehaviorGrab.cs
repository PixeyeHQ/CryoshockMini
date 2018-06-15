/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/8/2018 3:26 PM
================================================================*/


namespace Homebrew
{
	public class BehaviorGrab : Behavior,  IReceive<SignalTriggerEnter>
	{
	 

		public void HandleSignal(SignalTriggerEnter arg)
		{
			var hit = arg.other;
			var hitActor = hit.GetActor(Tag.ColliderInteract);
			if (hitActor == null) return;
			hitActor.SignalDispatch(new SignalInteract {other = actor}); 
		}
	}
}