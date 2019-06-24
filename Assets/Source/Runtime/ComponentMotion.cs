//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	sealed class ComponentMotion
	{
		public float speedMax;
		public Vector2 velocity;
		 
	}

	public static partial class HelperComponents
	{
		[RuntimeInitializeOnLoadMethod]
		static void ComponentMotionInit()
		{
			Storage<ComponentMotion>.Instance.Creator       = () => { return new ComponentMotion(); };
			Storage<ComponentMotion>.Instance.DisposeAction = ComponentMotionDispose;
		}

		static void ComponentMotionDispose(ComponentMotion component)
		{
			component.velocity = Vector2.zero;
		}

		internal static ComponentMotion ComponentMotion(in this ent entity)
		{
			return Storage<ComponentMotion>.Instance.components[entity.id];
		}
	}
}