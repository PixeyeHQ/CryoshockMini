//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	public class ComponentFace : IComponent
	{

		public float direction;
		public float directionOld;
		
		public void Copy(int entityID)
		{
			var component = Storage<ComponentFace>.Instance.GetFromStorage(entityID);
		}

		public void Dispose()
		{
		}

	}

	public static partial class HelperComponents
	{

		[RuntimeInitializeOnLoadMethod]
		static void ComponentFaceInit()
		{
			Storage<ComponentFace>.Instance.Creator = () => { return new ComponentFace(); };
		}

		public static ComponentFace ComponentFace(in this ent entity)
		{
			return Storage<ComponentFace>.Instance.components[entity.id];
		}

	}
}