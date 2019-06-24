//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;

namespace Pixeye
{
	static class AnimatorGuide
	{
		public delegate void Task(in ent entity, ComponentAnimator cAnimator);

		public static void Player(in ent entity, ComponentAnimator cAnimator)
		{
			var cMotion = entity.ComponentMotion();
			cAnimator.source.SetFloat(Anim.paramInput, Math.Abs(cMotion.velocity.x));
		}
	}
}