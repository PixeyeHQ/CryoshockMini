//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	public class ComponentObject : IComponent
	{

		public Vector3 position;

		public void Copy(int entityID)
		{
			var component = Storage<ComponentObject>.Instance.GetFromStorage(entityID);
		}

		public void Dispose()
		{
		}

	}

	public static partial class HelperComponents
	{

		[RuntimeInitializeOnLoadMethod]
		static void ComponentObjectInit()
		{
			Storage<ComponentObject>.Instance.Creator = () => { return new ComponentObject(); };
		}

		public static ComponentObject ComponentObject(this in ent entity)
		{
			return Storage<ComponentObject>.Instance.components[entity.id];
		}

	}
}