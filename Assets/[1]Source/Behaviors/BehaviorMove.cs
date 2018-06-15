/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 5:18 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class BehaviorMove : Behavior, ITickFixed, ITick
	{
		[Bind] private DataMove dataMove;
		[Bind(From.Object)] private Rigidbody2D rigid;

 
		private bool condition_blockmove;

	  
		protected override void OnTickFixed()
		{
			if (condition_blockmove)
				return;


			rigid.AddForce(dataMove.input * dataMove.spdAccelerate);

			rigid.velocity = new Vector2(dataMove.input.x > 0
					? Mathf.Min(rigid.velocity.x, dataMove.spdMax+dataMove.spdOffset)
					: Mathf.Max(rigid.velocity.x, -dataMove.spdMax-dataMove.spdOffset)
				, rigid.velocity.y);

			dataMove.velocity = rigid.velocity;
		}

	 

		public override void OnTagsChanged()
		{
			condition_blockmove = actor.tags.Contain(Tag.StateBlockMove);
			if (condition_blockmove) rigid.velocity = Vector2.zero;

			dataMove.spdOffset = 0;
			if (actor.tags.Contain(Tag.StateRage))
				dataMove.spdOffset = 0.5f;
			
		}
	}
}