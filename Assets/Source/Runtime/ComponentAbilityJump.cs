//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	sealed class ComponentAbilityJump
	{
		public float force;
		public bool working;
		public bool checkGround;
	}

	public static partial class HelperComponents
	{
		[RuntimeInitializeOnLoadMethod]
		static void ComponentAbilityJumpInit()
		{
			Storage<ComponentAbilityJump>.Instance.Creator       = () => { return new ComponentAbilityJump(); };
			Storage<ComponentAbilityJump>.Instance.DisposeAction = ComponentAbilityJump;
		}

		static void ComponentAbilityJump(ComponentAbilityJump component)
		{
			component.working     = false;
			component.checkGround = false;
			component.force       = 0.0f;
		}

		internal static ComponentAbilityJump ComponentAbilityJump(in this ent entity)
		{
			return Storage<ComponentAbilityJump>.Instance.components[entity.id];
		}
	}
}