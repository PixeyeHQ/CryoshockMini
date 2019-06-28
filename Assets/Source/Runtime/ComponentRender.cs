//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	struct ComponentRender
	{
		public SpriteRenderer source;
	}

	
	static partial class Components
	{
		public const string Render = "Pixeye.Source.ComponentRender";
		
		[RuntimeInitializeOnLoadMethod]
		static void ComponentRenderInit()
		{
			Storage<ComponentRender>.Instance.Creator = () => { return new ComponentRender(); };
		}
		static void ComponentRenderDispose(ComponentRender component)
		{
			component.source = null;
		}

		internal static ref ComponentRender ComponentRender(in this ent entity)
		{
			return ref Storage<ComponentRender>.Instance.components[entity.id];
		}
	}
}