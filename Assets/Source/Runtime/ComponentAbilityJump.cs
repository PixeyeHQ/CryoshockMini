//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	public class ComponentAbilityJump : IComponent
	{
		 
		public float force;
		public bool working;
		public bool checkGround;
		
		public void Copy(int entityID)
		{
			var component = Storage<ComponentAbilityJump>.Instance.GetFromStorage(entityID);
		}

		public void Dispose()
		{
			working = false;
		}

	}

	public static partial class HelperComponents
	{

		[RuntimeInitializeOnLoadMethod]
		static void ComponentAbilityJumpInit()
		{
			Storage<ComponentAbilityJump>.Instance.Creator = () => { return new ComponentAbilityJump(); };
		}

		public static ComponentAbilityJump ComponentAbilityJump(in this ent entity)
		{
			return Storage<ComponentAbilityJump>.Instance.components[entity.id];
		}

	}
}