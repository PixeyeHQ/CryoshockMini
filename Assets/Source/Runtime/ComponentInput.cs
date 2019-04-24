//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	public class ComponentInput : IComponent
	{

		public KeyCode InputMoveRight;
		public KeyCode InputMoveLeft;
		public KeyCode InputJump;
		public KeyCode InputShoot;

		
		
		public void Copy(int entityID)
		{
			var component = Storage<ComponentInput>.Instance.GetFromStorage(entityID);
		}

		public void Dispose()
		{
		}

	}

	public static partial class HelperComponents
	{

		[RuntimeInitializeOnLoadMethod]
		static void ComponentInputInit()
		{
			Storage<ComponentInput>.Instance.Creator = () => { return new ComponentInput(); };
		}

		public static ComponentInput ComponentInput(this in ent entity)
		{
			return Storage<ComponentInput>.Instance.components[entity.id];
		}

	}
}