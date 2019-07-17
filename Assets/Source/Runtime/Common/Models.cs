//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye.Source
{
	[CreateAssetMenu]
	public class Models : ScriptableBuild
	{
		public static void Player(in ent entity)
		{
			ref var cFace        = ref entity.Set<ComponentFace>();
			ref var cAbilityJump = ref entity.Set<ComponentAbilityJump>();
			ref var cAnimator    = ref entity.Set<ComponentAnimator>();
			ref var cRender      = ref entity.Set<ComponentRender>();
			ref var cMotion      = ref entity.Set<ComponentMotion>();
			ref var cRigid       = ref entity.Set<ComponentRigid>();
			ref var cObject      = ref entity.Set<ComponentObject>();
			ref var cInput       = ref entity.Set<ComponentInput>();
			ref var cWeapon      = ref entity.Set<ComponentWeapon>();

			// Component Face
			cFace.direction = 1;
			// Component Ability Jump
			cAbilityJump.force = 240;
			// Component Animator
			cAnimator.current                          = Anim.IDLE;
			cAnimator.guide                            = AnimatorGuidePlayer.Use;
			cAnimator.source                           = entity.GetMono<Animator>();
			cAnimator.source.runtimeAnimatorController = Box.Get<RuntimeAnimatorController>("Animator Hero Pistol");
			// Component Render
			cRender.source = entity.GetMono<SpriteRenderer>();
			// Component Motion
			cMotion.speedMax = 1.25f;
			// Component Rigidbody
			cRigid.source = entity.GetMono<Rigidbody2D>();
			// Component Object
			cObject.position = cRigid.source.position;
			// Component Input
			cInput.inputJump      = KeyCode.Space;
			cInput.inputShoot     = KeyCode.Z;
			cInput.inputMoveLeft  = KeyCode.LeftArrow;
			cInput.inputMoveRight = KeyCode.RightArrow;
			// Component Weapon
			cWeapon.t        = 0.0f;
			cWeapon.timeRate = 0.1f;

			entity.transform.name = $"{entity.id} Obj Player";
		}


		public static void Monster(in ent entity)
		{
			ref var cFace      = ref entity.Set<ComponentFace>();
			ref var cAnimator  = ref entity.Set<ComponentAnimator>();
			ref var cRender    = ref entity.Set<ComponentRender>();
			ref var cMotion    = ref entity.Set<ComponentMotion>();
			ref var cRigid     = ref entity.Set<ComponentRigid>();
			ref var cObject    = ref entity.Set<ComponentObject>();
			ref var cAI        = ref entity.Set<ComponentAI>();
			ref var cCollision = ref entity.Set<ComponentCollision>();

			// Component Face
			cFace.direction = 1;
			// Component Animator
			cAnimator.current                          = Anim.IDLE;
			cAnimator.guide                            = AnimatorGuideMonster.Use;
			cAnimator.source                           = entity.GetMono<Animator>();
			cAnimator.source.runtimeAnimatorController = Box.Get<RuntimeAnimatorController>("Animator Monster");
			// Component Render
			cRender.source = entity.GetMono<SpriteRenderer>();
			// Component Motion
			cMotion.speedMax = 1.25f;
			// Component Rigidbody
			cRigid.source = entity.GetMono<Rigidbody2D>();
			// Component Object
			cObject.position = cRigid.source.position;
			// Component AI
			cAI.speedMax = 1;
			// Component Collision
			cCollision.source = entity.GetMono<Collider2D>();


			entity.transform.name = $"{entity.id} Obj Monster";
		}
	}
}