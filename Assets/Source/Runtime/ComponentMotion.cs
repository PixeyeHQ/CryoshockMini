//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	public class ComponentMotion : IComponent
	{

		public float speedMax;

		public void Copy(int entityID)
		{
			var component = Storage<ComponentMotion>.Instance.GetFromStorage(entityID);
		}

		public void Dispose()
		{
		}

	}

	public static partial class HelperComponents
	{

		[RuntimeInitializeOnLoadMethod]
		static void ComponentMotionInit()
		{
			Storage<ComponentMotion>.Instance.Creator = () => { return new ComponentMotion(); };
		}

		public static ComponentMotion ComponentMotion(this in ent entity)
		{
			return Storage<ComponentMotion>.Instance.components[entity.id];
		}

	}
}