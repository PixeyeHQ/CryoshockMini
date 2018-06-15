/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/7/2018 11:52 AM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class BehaviorJump : Behavior, ITick
	{
		private bool conditionInTheAir;
		[Bind]
		private DataMove dataMove;
		public override void OnTick()
		{
			if (CanAct())
			{
				Handle();
			}

			conditionInTheAir = dataMove.velocity.y != 0;

		}

		void Handle()
		{
			Get<Rigidbody2D>().AddForce(Vector2.up * Get<DataMove>().jumpForce);
	 
		}

		bool CanAct()
		{
			return Input.GetKeyDown(KeyCode.Space) && !conditionInTheAir;
		}

 
	}
}