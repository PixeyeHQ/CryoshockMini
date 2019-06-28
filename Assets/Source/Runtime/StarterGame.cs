using Pixeye;
using Pixeye.Framework;
using Pixeye.Source;

public class StarterGame : Starter
{
	protected override void Setup()
	{
		Add<ProcessorGame>();
		Add<ProcessorPlayer>();
		Add<ProcessorShoot>();
		Add<ProcessorAnimations>();

		Actor.Create("Obj Unit", Models.Player);
	}
}