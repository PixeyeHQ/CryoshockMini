//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games


using System;
using UnityEngine;
using Pixeye.Framework;
using System.Runtime.CompilerServices;


namespace Pixeye.Source
{
	[Serializable]
	struct ComponentWeapon
	{
		public float timeRate;
		public float t;
	}

 
	static partial class Components
	{
		public const string Weapon = "Pixeye.Source.ComponentWeapon";

		[RuntimeInitializeOnLoadMethod]
		static void ComponentWeaponInit()
		{
			Storage<ComponentWeapon>.Instance.DisposeAction = DisposeComponentWeapon;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void DisposeComponentWeapon(in ent entity)
		{
			ref var component = ref Storage<ComponentWeapon>.Instance.components[entity.id];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static ref ComponentWeapon ComponentWeapon(in this ent entity)
		{
			return ref Storage<ComponentWeapon>.Instance.components[entity.id];
		}
	}

 
}