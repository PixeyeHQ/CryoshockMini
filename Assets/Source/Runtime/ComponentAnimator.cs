//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEditor.Animations;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	sealed class ComponentAnimator
	{
		public AnimatorGuide.Task guide;
		public Animator source;
		public int current;
	}

	static partial class HelperComponents
	{
		[RuntimeInitializeOnLoadMethod]
		static void ComponentAnimationsInit()
		{
			Storage<ComponentAnimator>.Instance.Creator       = () => { return new ComponentAnimator(); };
			Storage<ComponentAnimator>.Instance.DisposeAction = ComponentAnimatorDispose;
		}

		static void ComponentAnimatorDispose(ComponentAnimator component)
		{
		}

		internal static ComponentAnimator ComponentAnimator(this in ent entity)
		{
			return Storage<ComponentAnimator>.Instance.components[entity.id];
		}
	}
}