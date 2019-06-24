//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	sealed class ComponentInput
	{
		public KeyCode inputMoveRight;
		public KeyCode inputMoveLeft;
		public KeyCode inputShoot;
		public KeyCode inputJump;
	}

	public static partial class HelperComponents
	{
		[RuntimeInitializeOnLoadMethod]
		static void ComponentInputInit()
		{
			Storage<ComponentInput>.Instance.Creator       = () => { return new ComponentInput(); };
			Storage<ComponentInput>.Instance.DisposeAction = ComponentInputDispose;
		}

		static void ComponentInputDispose(ComponentInput component)
		{
		}

		internal static ComponentInput ComponentInput(this in ent entity)
		{
			return Storage<ComponentInput>.Instance.components[entity.id];
		}
	}
}