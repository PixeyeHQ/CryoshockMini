using Pixeye;
using Pixeye.Framework;

public class StarterGame : Starter
{

	protected override void Setup()
	{
		Add<ProcessorGame>();
		Add<ProcessorPlayer>();
		Add<ProcessorAnimations>();

		Actor.Create("Obj Unit", Models.Player);
	}

}