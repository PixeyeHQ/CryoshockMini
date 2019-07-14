//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;

namespace Pixeye
{
	abstract class AnimatorGuide
	{
		public abstract void Do(in ent entity, ComponentAnimator cAnimator);
	}
}