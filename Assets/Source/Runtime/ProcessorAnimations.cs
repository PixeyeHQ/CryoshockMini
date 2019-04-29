//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games


using Pixeye.Framework;


namespace Pixeye
{
	public class ProcessorAnimations : Processor, ITick
	{

		private Group<ComponentAnimator> groupOfAnimators;

		public void Tick()
		{
			foreach (ent entity in groupOfAnimators)
			{
				var cAnimator = entity.ComponentAnimator();
				cAnimator.guide(entity, cAnimator);
			}
		}

	}
}