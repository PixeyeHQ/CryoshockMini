//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games


using Pixeye.Framework;


namespace Pixeye
{
	class ProcessorAnimations : Processor, ITick
	{
		public Group<ComponentAnimator> groupOfAnimators;

		public void Tick(float delta)
		{
			foreach (ent entity in groupOfAnimators)
			{
				var cAnimator = entity.ComponentAnimator();
				cAnimator.guide(entity, cAnimator);
			}
		}
	}
}