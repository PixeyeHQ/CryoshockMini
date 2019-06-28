//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	struct ComponentMotion
	{
		public float speedMax;
		public Vector2 velocity;
	}
	
	static partial class Components
	{

		public const string Motion = "Pixeye.Source.ComponentMotion";
		
		[RuntimeInitializeOnLoadMethod]
		static void ComponentMotionInit()
		{
			Storage<ComponentMotion>.Instance.Creator       = () => { return new ComponentMotion(); };
			Storage<ComponentMotion>.Instance.DisposeAction = ComponentMotionDispose;
		}

		static void ComponentMotionDispose(in ent entity)
		{
			ref var component = ref Storage<ComponentMotion>.Instance.components[entity.id];

			component.velocity = Vector2.zero;
		}

		internal static ref ComponentMotion ComponentMotion(in this ent entity)
		{
			return ref Storage<ComponentMotion>.Instance.components[entity.id];
		}
	}
}