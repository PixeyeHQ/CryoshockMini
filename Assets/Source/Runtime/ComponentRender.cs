//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	sealed class ComponentRender
	{
		public SpriteRenderer source;
	}

	public static partial class HelperComponents
	{
		[RuntimeInitializeOnLoadMethod]
		static void ComponentRenderInit()
		{
			Storage<ComponentRender>.Instance.Creator = () => { return new ComponentRender(); };
		}
		static void ComponentRenderDispose(ComponentRender component)
		{
			component.source = null;
		}

		internal static ComponentRender ComponentRender(in this ent entity)
		{
			return Storage<ComponentRender>.Instance.components[entity.id];
		}
	}
}