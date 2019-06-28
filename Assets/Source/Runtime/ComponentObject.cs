//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	struct ComponentObject
	{
		public Vector3 position;
	}

	public static partial class HelperComponents
	{
		[RuntimeInitializeOnLoadMethod]
		static void ComponentObjectInit()
		{
			Storage<ComponentObject>.Instance.Creator = () => { return new ComponentObject(); };
			Storage<ComponentObject>.Instance.DisposeAction = ComponentObjectDispose;
		}

		static void ComponentObjectDispose(in ent entity)
		{
			
		}
		
		internal static ref ComponentObject ComponentObject(in this ent entity)
		{
			return ref Storage<ComponentObject>.Instance.components[entity.id];
		}
	}
}