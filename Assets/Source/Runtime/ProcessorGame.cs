//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	class ProcessorGame : Processor, ITick
	{
		public Group<ComponentFace, ComponentRender> groupToFlip;
		public Group<ComponentFace, ComponentMotion> groupToControlFace;
		public Group<ComponentObject> groupFallingObjects;

		public void Tick(float delta)
		{
			foreach (ent entity in groupToFlip)
			{
				ref var cFace   = ref entity.ComponentFace();
				ref var cRender = ref entity.ComponentRender();

				if (cFace.direction != cFace.directionOld)
				{
					cRender.source.flipX = cFace.direction < 0;
					cFace.directionOld   = cFace.direction;
				}
			}

			foreach (ent entity in groupToControlFace)
			{
				ref var cFace   = ref entity.ComponentFace();
				ref var cMotion = ref entity.ComponentMotion();

				if (cMotion.velocity.x > 0)
					cFace.direction = 1;
				else if (cMotion.velocity.x < 0)
					cFace.direction = -1;
			}


			foreach (ent entity in groupFallingObjects)
			{
				ref var cObject  = ref entity.ComponentObject();
				ref var position = ref cObject.position;

				if (position.y < -1.35f)
				{
					entity.Release();

					if (entity.Has<ComponentInput>())
					{
						ProcessorScene.To(0);
					}
				}
			}
		}
	}
}