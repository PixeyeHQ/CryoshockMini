//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	public static class Models
	{
		public static void Player(in ent entity)
		{
			entity.Set<ComponentFace>();

			var cAbilityJump = entity.Set<ComponentAbilityJump>();
			var cAnimator    = entity.Set<ComponentAnimator>();
			var cRender      = entity.Set<ComponentRender>();
			var cMotion      = entity.Set<ComponentMotion>();
			var cRigid       = entity.Set<ComponentRigid>();
			var cObject      = entity.Set<ComponentObject>();
			var cInput       = entity.Set<ComponentInput>();

			cAbilityJump.force = 240;

			cAnimator.current                          = Anim.IDLE;
			cAnimator.guide                            = AnimatorGuide.Player;
			cAnimator.source                           = entity.GetMono<Animator>();
			cAnimator.source.runtimeAnimatorController = Box.Get<RuntimeAnimatorController>("Animator Hero Pistol");

			cRender.source = entity.GetMono<SpriteRenderer>();

			cMotion.speedMax = 1.25f;
			
			cRigid.source = entity.GetMono<Rigidbody2D>();

			cObject.position = cRigid.source.position;

			cInput.inputJump      = KeyCode.Space;
			cInput.inputShoot     = KeyCode.Z;
			cInput.inputMoveLeft  = KeyCode.LeftArrow;
			cInput.inputMoveRight = KeyCode.RightArrow;


			entity.transform.name = $"{entity.id} Obj Player";
		}
	}
}