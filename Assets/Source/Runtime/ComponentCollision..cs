//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games


using UnityEngine;
using Pixeye.Framework;
using System.Runtime.CompilerServices;


namespace Pixeye.Source
{
	struct ComponentCollision
	{
		public Collider2D source;
	}


	#region HELPERS

	static partial class Components
	{
		public const string Collision = "Pixeye.Source.ComponentCollision";

		[RuntimeInitializeOnLoadMethod]
		static void ComponentCollisionInit()
		{
			Storage<ComponentCollision>.Instance.DisposeAction = DisposeComponentCollision;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void DisposeComponentCollision(in ent entity)
		{
			ref var component = ref Storage<ComponentCollision>.Instance.components[entity.id];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static ref ComponentCollision ComponentCollision(in this ent entity)
		{
			return ref Storage<ComponentCollision>.Instance.components[entity.id];
		}
	}

	#endregion
}