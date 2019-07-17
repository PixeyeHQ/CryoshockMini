//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games


using Pixeye.Framework;
using UnityEngine;

namespace Pixeye.Source
{
	static class Phys
	{
		public static readonly BufferSortedEntities buffer = new BufferSortedEntities(1024);

		public static bool GetEntity(out ent entity, Vector2 position, Vector2 direction, float distance, int mask)
		{
			var hit = Physics2D.Raycast(position, direction, distance, mask);
			if (hit)
			{
				var index = HelperArray.BinarySearch(ref buffer.pointers, hit.collider.GetHashCode(), 0, buffer.length);
				if (index == -1)
				{
					entity = new ent(-1);
					return false;
				}

				entity = buffer.entities[index];
				return true;
			}

			entity = new ent(-1);
			return false;
		}

		public static bool GetMonster(out ent entity, Vector2 position, Vector2 direction, float distance, int mask)
		{
			var hit = Physics2D.Raycast(position, direction, distance, mask);
			if (hit)
			{
		 
				var index = HelperArray.BinarySearch(ref buffer.pointers, hit.collider.GetHashCode(), 0, buffer.length);
				if (index == -1)
				{
					entity = new ent(-1);
					return false;
				}

				entity = buffer.entities[index];
				if (entity.Has<ComponentAI>())
					return true;
			}

			entity = new ent(-1);
			return false;
		}
	}
}