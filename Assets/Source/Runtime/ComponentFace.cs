//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	public class ComponentFace
	{

		public float direction;
		public float directionOld;

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