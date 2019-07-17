//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using Pixeye.Framework;

namespace Pixeye.Source
{
	sealed class ProcessorCollisions : Processor
	{
		Group<ComponentCollision> groupCollisions;

		public ProcessorCollisions()
		{
			groupCollisions.onAdd    += ToGroupCollisions;
			groupCollisions.onRemove += FromGroupCollisions;
		}

		void ToGroupCollisions(in ent entity)
		{
			Phys.buffer.Insert(entity, entity.ComponentCollision().source.GetHashCode());
		}

		void FromGroupCollisions(in ent entity)
		{
			Phys.buffer.Remove(entity.ComponentCollision().source.GetHashCode());
		}
	}
}