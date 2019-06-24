//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	sealed class ComponentRigid
	{
		public Rigidbody2D source;
	}

	public static partial class HelperComponents
	{
		[RuntimeInitializeOnLoadMethod]
		static void ComponentRigidInit()
		{
			Storage<ComponentRigid>.Instance.Creator       = () => { return new ComponentRigid(); };
			Storage<ComponentRigid>.Instance.DisposeAction = ComponentRigidDispose;
		}

		static void ComponentRigidDispose(ComponentRigid component)
		{
			component.source = null;
		}

		internal static ComponentRigid ComponentRigid(this in ent entity)
		{
			return Storage<ComponentRigid>.Instance.components[entity.id];
		}
	}
}