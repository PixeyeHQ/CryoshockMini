using Pixeye.Framework;
using Pixeye.Source;

public class StarterGame : Starter
{
	protected override void Setup()
	{
		Add<ProcessorCollisions>();
		Add<ProcessorGame>();
		Add<ProcessorPlayer>();
		Add<ProcessorMonster>();
		Add<ProcessorShoot>();
		Add<ProcessorAnimations>();

		Actor.Create(DataBase.Prefabs.Unit, Models.Player);
	}
}