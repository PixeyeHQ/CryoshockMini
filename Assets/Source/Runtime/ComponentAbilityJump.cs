//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	struct ComponentAbilityJump
	{
		public float timeJump;
		public float force;
		public bool working;
		public bool checkGround;
	}

	 static partial class Components
	{
		public const string AbilityJump = "Pixeye.Source.ComponentAbilityJump";
		
		[RuntimeInitializeOnLoadMethod]
		static void ComponentAbilityJumpInit()
		{
			Storage<ComponentAbilityJump>.Instance.Creator       = () => { return new ComponentAbilityJump(); };
			Storage<ComponentAbilityJump>.Instance.DisposeAction = ComponentAbilityJumpDispose;
		}

		static void ComponentAbilityJumpDispose(in ent entity)
		{
			ref var component = ref Storage<ComponentAbilityJump>.Instance.components[entity.id];
			component.working     = false;
			component.checkGround = false;
			component.force       = 0.0f;
		}

		internal static ref ComponentAbilityJump ComponentAbilityJump(in this ent entity)
		{
			return ref Storage<ComponentAbilityJump>.Instance.components[entity.id];
		}
	}
}