//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	public class ComponentRender : IComponent
	{

		public SpriteRenderer source;
		
		public void Copy(int entityID)
		{
			var component = Storage<ComponentRender>.Instance.GetFromStorage(entityID);
		}

		public void Dispose()
		{
		}

	}

	public static partial class HelperComponents
	{

		[RuntimeInitializeOnLoadMethod]
		static void ComponentRenderInit()
		{
			Storage<ComponentRender>.Instance.Creator = () => { return new ComponentRender(); };
		}

		public static ComponentRender ComponentRender(in this ent entity)
		{
			return Storage<ComponentRender>.Instance.components[entity.id];
		}

	}
}