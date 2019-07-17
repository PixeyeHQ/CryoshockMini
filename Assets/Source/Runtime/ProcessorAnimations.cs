//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games


using Pixeye.Framework;


namespace Pixeye.Source
{
	class ProcessorAnimations : Processor, ITick
	{
		public Group<ComponentAnimator> groupOfAnimators;

		public void Tick(float delta)
		{
			foreach (ent entity in groupOfAnimators)
			{
				ref var cAnimator = ref entity.ComponentAnimator();
				cAnimator.guide.Do(entity, cAnimator);
			}
		}
	}
}