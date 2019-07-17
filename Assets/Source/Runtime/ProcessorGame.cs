//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using Pixeye.Framework;
using Pixeye.Source;
using UnityEngine;

namespace Pixeye.Source
{
	class ProcessorGame : Processor, ITick
	{
		const float timerSpawnMob = 0.5f;

		public Group<ComponentFace, ComponentRender> groupToFlip;
		public Group<ComponentFace, ComponentMotion> groupToControlFace;
		public Group<ComponentObject> groupFallingObjects;

		float alarmSpawnMob;

		public void Tick(float delta)
		{
			if (alarmSpawnMob.PlusCheck(delta, timerSpawnMob))
			{
				var actor = Actor.Create(DataBase.Prefabs.Unit, Models.Monster, new Vector3(0, 2, 0), true);
				actor.entity.ComponentAI().blockMovement = true;
				Timer.Add(0.35f, () => actor.entity.ComponentAI().blockMovement = false);

				alarmSpawnMob = 0.0f;
			}


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