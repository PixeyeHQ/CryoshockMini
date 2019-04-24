//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	public class ProcessorPlayer : Processor, ITick
	{

		public Group<ComponentInput, ComponentMotion, ComponentRigid> groupOfPlayers;

		public void Tick()
		{
			foreach (var entity in groupOfPlayers)
			{
				var cInput = entity.ComponentInput();
				var cRigid = entity.ComponentRigid();
				var cMotion = entity.ComponentMotion();

				var velocity = cRigid.source.velocity;

				var moveLeft = Input.GetKey(cInput.InputMoveLeft);
				var moveRight = Input.GetKey(cInput.InputMoveRight);

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

				if (Input.GetKeyDown(cInput.InputJump))
				{
					cRigid.source.AddForce(new Vector2(0, 240));
				}
			}
		}

	}
}