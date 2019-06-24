//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using Pixeye.Framework;
using UnityEngine;
using Time = Pixeye.Framework.Time;

namespace Pixeye
{
	class ProcessorPlayer : Processor, ITick
	{
		public Group<ComponentInput, ComponentMotion, ComponentRigid, ComponentObject> groupAll;
		public Group<ComponentInput, ComponentAbilityJump, ComponentRigid> groupJumping;


		public void Tick(float delta)
		{
			foreach (var entity in groupAll)
			{
				var cInput  = entity.ComponentInput();
				var cRigid  = entity.ComponentRigid();
				var cMotion = entity.ComponentMotion();
				var cObject = entity.ComponentObject();

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

			foreach (var entity in groupJumping)
			{
				var cInput       = entity.ComponentInput();
				var cAbilityJump = entity.ComponentAbilityJump();
				var cObject      = entity.ComponentObject();

				if (cAbilityJump.checkGround)
				{
					var hit = Physics2D.Raycast(cObject.position, Vector2.down, 0.15f, 1 << 10);
					if (hit)
					{
						cAbilityJump.working     = false;
						cAbilityJump.checkGround = false;
					}
				}

				if (Input.GetKeyDown(cInput.inputJump) && !cAbilityJump.working)
				{
					var cRigid = entity.ComponentRigid();
					cAbilityJump.working = true;

					cRigid.source.AddForce(new Vector2(0, cAbilityJump.force));
					Timer.Add(Time.deltaFixed * 10, () => { cAbilityJump.checkGround = true; }); // not a good habbyt.
				}
			}
		}
	}
}