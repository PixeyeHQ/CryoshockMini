/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 6:39 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class BehaviorAIProcessing : Behavior, ITick
	{
		[Bind] private DataMove dataMove;

		protected override void Setup()
		{
			dataMove.face = Random.value > 0.5 ? -1 : 1;
			actor.tags.Add(Tag.StateBlockMove);
			Timer.Add(0.5f, () => actor.tags.Remove(Tag.StateBlockMove));
		}

		public override void OnTick()
		{
			dataMove.input = new Vector2(dataMove.face, 0);
		}
	}
}