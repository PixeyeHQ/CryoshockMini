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
			composer.Add<ComponentFace>();

			var cAbilityJump = composer.Add<ComponentAbilityJump>();
			var cAnimator = composer.Add<ComponentAnimator>();
			var cRender = composer.Add<ComponentRender>();
			var cMotion = composer.Add<ComponentMotion>();
			var cRigid = composer.Add<ComponentRigid>();
			var cObject = composer.Add<ComponentObject>();
			var cInput = composer.Add<ComponentInput>();

			cAbilityJump.force = 240;

			cAnimator.current = Anim.IDLE;
			cAnimator.guide = AnimatorGuide.Player;
			cAnimator.source = composer.entity.Get<Animator>();
			cAnimator.source.runtimeAnimatorController = Box.Get<RuntimeAnimatorController>("Animator Hero Pistol");

			cRender.source = composer.entity.Get<SpriteRenderer>();

			cMotion.speedMax = 1.25f;

			cRigid.source = composer.entity.Get<Rigidbody2D>();

			cObject.position = cRigid.source.position;

			cInput.inputJump = KeyCode.Space;
			cInput.inputShoot = KeyCode.Z;
			cInput.inputMoveLeft = KeyCode.LeftArrow;
			cInput.inputMoveRight = KeyCode.RightArrow;

			composer.entity.transform.name = $"Obj Player [{composer.entity.id}]";
		}

	}
}