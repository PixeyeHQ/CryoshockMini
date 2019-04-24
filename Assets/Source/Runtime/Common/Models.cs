//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	public static class Models
	{

		public static void Player(EntityComposer composer)
		{
			composer.Add<ComponentRigid>();

			var cAnimation = composer.Add<ComponentAnimations>();
			var cMotion = composer.Add<ComponentMotion>();
			var cInput = composer.Add<ComponentInput>();

			cAnimation.source = Box.Get<RuntimeAnimatorController>("Animator Hero Pistol");
			cAnimation.current = Anim.IDLE;

			cMotion.speedMax = 1.25f;

			cInput.InputJump = KeyCode.Space;
			cInput.InputShoot = KeyCode.Z;
			cInput.InputMoveLeft = KeyCode.LeftArrow;
			cInput.InputMoveRight = KeyCode.RightArrow;
		}

	}
}