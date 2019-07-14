//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;

namespace Pixeye.Source
{
	sealed class AnimatorGuidePlayer : AnimatorGuide
	{
		public static AnimatorGuidePlayer Use = new AnimatorGuidePlayer();

		public override void Do(in ent entity, ComponentAnimator cAnimator)
		{
			var cMotion = entity.ComponentMotion();
			cAnimator.source.SetFloat(Anim.PARAM_X, Math.Abs(cMotion.velocity.x));
			cAnimator.source.SetFloat(Anim.PARAM_Y, Math.Abs(cMotion.velocity.y));
		}
	}
}