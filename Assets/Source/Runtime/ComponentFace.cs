//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	struct ComponentFace
	{
		public float direction;
		public float directionOld;
	}

  static partial class Components
	{
		public const string Face = "Pixeye.Source.ComponentFace";
		
		[RuntimeInitializeOnLoadMethod]
		static void ComponentFaceInit()
		{
			Storage<ComponentFace>.Instance.Creator       = () => { return new ComponentFace(); };
			Storage<ComponentFace>.Instance.DisposeAction = ComponentFaceDispose;
		}

		static void ComponentFaceDispose(in ent entity)
		{
			ref var component = ref Storage<ComponentFace>.Instance.components[entity.id];
			component.direction    = 0;
			component.directionOld = 0;
		}

		internal static ref ComponentFace ComponentFace(in this ent entity)
		{
			return ref Storage<ComponentFace>.Instance.components[entity.id];
		}
	}
}