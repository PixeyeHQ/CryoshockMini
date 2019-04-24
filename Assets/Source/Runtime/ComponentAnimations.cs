//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	public class ComponentAnimations : IComponent
	{

		public RuntimeAnimatorController source;
		public int current;
		
		public void Copy(int entityID)
		{
			var component = Storage<ComponentAnimations>.Instance.GetFromStorage(entityID);
		}

		public void Dispose()
		{
		}

	}

	public static partial class HelperComponents
	{

		[RuntimeInitializeOnLoadMethod]
		static void ComponentAnimationsInit()
		{
			Storage<ComponentAnimations>.Instance.Creator = () => { return new ComponentAnimations(); };
		}

		public static ComponentAnimations ComponentAnimations(this in ent entity)
		{
			return Storage<ComponentAnimations>.Instance.components[entity.id];
		}

	}
}