//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	sealed class ComponentFace
	{
		public float direction;
		public float directionOld;
	}

	public static partial class HelperComponents
	{
		[RuntimeInitializeOnLoadMethod]
		static void ComponentFaceInit()
		{
			Storage<ComponentFace>.Instance.Creator       = () => { return new ComponentFace(); };
			Storage<ComponentFace>.Instance.DisposeAction = ComponentFaceDispose;
		}

		static void ComponentFaceDispose(ComponentFace component)
		{
			component.direction    = 0;
			component.directionOld = 0;
		}

		internal static ComponentFace ComponentFace(in this ent entity)
		{
			return Storage<ComponentFace>.Instance.components[entity.id];
		}
	}
}