//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEditor.Animations;
using UnityEngine;

namespace Pixeye
{
	[Serializable]
	public class ComponentAnimator : IComponent
	{

		public AnimatorGuide.Task guide;
		public Animator source;
		public int current;
		
		public void Copy(int entityID)
		{
			var component = Storage<ComponentAnimator>.Instance.GetFromStorage(entityID);
		}

		public void Dispose()
		{
		}

	}

	public static partial class HelperComponents
	{

		[RuntimeInitializeOnLoadMethod]
		static void ComponentAnimationsInit()
		{
			Storage<ComponentAnimator>.Instance.Creator = () => { return new ComponentAnimator(); };
		}

		public static ComponentAnimator ComponentAnimator(this in ent entity)
		{
			return Storage<ComponentAnimator>.Instance.components[entity.id];
		}

	}
}