//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	public class ProcessorGame : Processor, ITick
	{

		private Group<ComponentFace, ComponentRender> groupToFlip;
		private Group<ComponentFace, ComponentMotion> groupToControlFace;

		public void Tick(float delta)
		{
			foreach (ent entity in groupToFlip)
			{
				var cFace = entity.ComponentFace();
				var cRender = entity.ComponentRender();

				if (cFace.direction != cFace.directionOld)
				{
					cRender.source.flipX = cFace.direction < 0;
					cFace.directionOld = cFace.direction;
				}
			}

			foreach (ent entity in groupToControlFace)
			{
				var cFace = entity.ComponentFace();
				var cMotion = entity.ComponentMotion();

				if (cMotion.velocity.x > 0)
					cFace.direction = 1;
				else if (cMotion.velocity.x < 0)
					cFace.direction = -1;
			}
		}

	}
}