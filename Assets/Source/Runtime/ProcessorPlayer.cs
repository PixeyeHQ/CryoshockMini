//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using Pixeye.Framework;
using UnityEngine;


namespace Pixeye.Source
{
	class ProcessorPlayer : Processor, ITick
	{
		public Group<ComponentInput, ComponentMotion, ComponentRigid, ComponentObject> groupAll;
		public Group<ComponentInput, ComponentAbilityJump, ComponentRigid> groupJumping;


		public void Tick(float delta)
		{
		 
			// Move
			foreach (var entity in groupAll)
			{
				ref var cInput  = ref entity.ComponentInput();
				ref var cRigid  = ref entity.ComponentRigid();
				ref var cMotion = ref entity.ComponentMotion();
				ref var cObject = ref entity.ComponentObject();

				var velocity = cRigid.source.velocity;

				var moveLeft  = Input.GetKey(cInput.inputMoveLeft);
				var moveRight = Input.GetKey(cInput.inputMoveRight);

				if (moveLeft || moveRight)
				{
					if (moveRight)
					{
						velocity.x = cMotion.speedMax;
					}

					if (moveLeft)
					{
						velocity.x = -cMotion.speedMax;
					}
				}
				else velocity.x = 0;

				cRigid.source.velocity = velocity;
				cMotion.velocity       = velocity;
				cObject.position       = cRigid.source.position;
			}

			// Jump
			foreach (var entity in groupJumping)
			{
				ref var cInput       = ref entity.ComponentInput();
				ref var cAbilityJump = ref entity.ComponentAbilityJump();
				ref var cObject      = ref entity.ComponentObject();

				if (cAbilityJump.checkGround)
				{
					var hit = Physics2D.Raycast(cObject.position, Vector2.down, 0.15f, 1 << 10);
					if (hit)
					{
						cAbilityJump.working     = false;
						cAbilityJump.checkGround = false;
					}
				}
				else
				{
					if (cAbilityJump.timeJump.PlusCheck(delta, 0.1f))
					{
						cAbilityJump.checkGround = true;
					}
				}

				if (Input.GetKeyDown(cInput.inputJump) && !cAbilityJump.working)
				{
					ref var cRigid = ref entity.ComponentRigid();
					cAbilityJump.working  = true;
					cAbilityJump.timeJump = 0.0f;
					cRigid.source.AddForce(new Vector2(0, cAbilityJump.force));
				}
			}
		}
	}
}