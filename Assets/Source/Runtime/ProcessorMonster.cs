//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye.Source
{
	sealed class ProcessorMonster : Processor, ITick
	{
		const float AI_RANGE = 0.06f;
		const int AI_MASK = 1 << 10;

		public Group<ComponentAI, ComponentMotion, ComponentObject, ComponentRigid> groupMonster;

		public ProcessorMonster()
		{
			groupMonster.onAdd += ToGroupMonster;
		}

		void ToGroupMonster(in ent entity)
		{
			entity.ComponentAI().direction = this.Between(-1, 1);
		}

		public void Tick(float delta)
		{
			for (int i = 0; i < groupMonster.length; i++)
			{
				ref var entity = ref groupMonster.entities[i];

				ref var cObject = ref entity.ComponentObject();
				ref var cAI     = ref entity.ComponentAI();
				ref var cMotion = ref entity.ComponentMotion();
				ref var cRigid  = ref entity.ComponentRigid();

				var velocity = cRigid.source.velocity;
				var speed    = cAI.blockMovement ? 0 : cAI.speedMax;

				var hit = Physics2D.Raycast(cObject.position, new Vector2(cAI.direction, 0), AI_RANGE, AI_MASK);
				if (hit)
				{
					cAI.direction *= -1;
				}

				cRigid.source.velocity = cMotion.velocity = new Vector2(cAI.direction * speed, velocity.y);
				cObject.position       = cRigid.source.position;
			}
		}
	}
}