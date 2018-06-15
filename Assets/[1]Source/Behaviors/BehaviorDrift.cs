/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/8/2018 11:41 AM
================================================================*/


namespace Homebrew
{
	public class BehaviorDrift : Behavior, IReceive<SignalTags>
	{
		[Bind] private DataMove dataMove;


		public void HandleSignal(SignalTags arg)
		{
			if (arg.tag != Tag.SignalDrift) return;
			Get<DataAnimation>().animationState = TagAnimations.STOP;

			dataMove.face = -dataMove.face;
			dataMove.faceOverride = dataMove.face;
			dataMove.faceCache = 0;
		}


		public override void OnTagsChanged()
		{
			var condition = actor.tags.Contain(Tag.StateDrifting);
			if (!condition)
			{
				dataMove.face = dataMove.faceOverride;
				dataMove.faceOverride = 0;
				dataMove.faceCache = 0;
			}
		}
	}
}