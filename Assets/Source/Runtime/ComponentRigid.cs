//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	struct ComponentRigid
	{
		public Rigidbody2D source;
	}

	
	static partial class Components
	{
		public const string Rigid = "Pixeye.Source.ComponentRigid";
		
		[RuntimeInitializeOnLoadMethod]
		static void ComponentRigidInit()
		{
			Storage<ComponentRigid>.Instance.Creator       = () => { return new ComponentRigid(); };
			Storage<ComponentRigid>.Instance.DisposeAction = ComponentRigidDispose;
		}

		static void ComponentRigidDispose(in ent entity)
		{
			ref var component = ref Storage<ComponentRigid>.Instance.components[entity.id];
			component.source = null;
		}

		internal static ref ComponentRigid ComponentRigid(this in ent entity)
		{
			return ref Storage<ComponentRigid>.Instance.components[entity.id];
		}
	}
}