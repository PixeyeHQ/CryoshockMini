//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEditor.Animations;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	struct ComponentAnimator
	{
		public AnimatorGuide guide;
		public Animator source;
		public int current;
	}

	static partial class Components
	{
		public const string Animator = "Pixeye.Source.ComponentAnimator";
		
		[RuntimeInitializeOnLoadMethod]
		static void ComponentAnimationsInit()
		{
			Storage<ComponentAnimator>.Instance.Creator       = () => { return new ComponentAnimator(); };
			Storage<ComponentAnimator>.Instance.DisposeAction = ComponentAnimatorDispose;
		}

		static void ComponentAnimatorDispose(in ent entity)
		{
			ref var component = ref Storage<ComponentAnimator>.Instance.components[entity.id];
			component.source = null;
		}

		internal static ref ComponentAnimator ComponentAnimator(this in ent entity)
		{
			return ref Storage<ComponentAnimator>.Instance.components[entity.id];
		}
	}
}