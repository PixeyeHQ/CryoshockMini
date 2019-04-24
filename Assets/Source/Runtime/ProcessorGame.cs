//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	public class ProcessorGame : Processor
	{

		public Group<ComponentRigid> groupOfRigids;

		public ProcessorGame()
		{
			groupOfRigids.onAdd += AwakeInGroupOfRigids;
		}

		void AwakeInGroupOfRigids(in ent entity)
		{
			entity.ComponentRigid().source = entity.Get<Rigidbody2D>();
		}

	}
}