/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 9:09 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class BehaviorSense : Behavior, ITick
	{
		[Bind] private DataRaycast data;
		[Bind] private DataMove dataMove;


		public override void OnTick()
		{
		 	if (UnityEngine.Time.frameCount % 5 != 0) return;
			data.amount = 	Physics2D.RaycastNonAlloc(actor.selfTransform.position, Vector2.right * dataMove.face, data.hits, 0.1f);
		}
	}
}