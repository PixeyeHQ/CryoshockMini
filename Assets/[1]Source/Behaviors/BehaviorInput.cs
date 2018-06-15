/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/7/2018 7:59 AM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class BehaviorInput : Behavior, ITick
	{
		[Bind] private DataMove dataMove;
		float x;
		private float sp;
		private bool condition_drift;

		protected override void Setup()
		{
			sp = Time.DeltaTime * 10;
		}

		void HandleDrift()
		{
			if (condition_drift) return;
			condition_drift = true;
			actor.SignalDispatch(new SignalTags {tag = Tag.SignalDrift});
			Timer.Add(0.5f, () =>
			{
				condition_drift = false;
				sp = Time.DeltaTime * 10;
			});
			sp = Time.DeltaTime * 3;
		}

		public override void OnTick()
		{
			var xAbs = Mathf.Abs(dataMove.velocity.x);
			var condition_horizontal = Input.GetAxisRaw("Horizontal");
			var delta = Mathf.Abs(dataMove.face - condition_horizontal);

			if (delta > 1 && xAbs > 0.9f)
			{
				HandleDrift();
			}
			else dataMove.face = condition_horizontal != 0 ? condition_horizontal : dataMove.face;

			x = Mathf.Lerp(x, condition_horizontal, sp);
			dataMove.input = new Vector2(x, dataMove.input.y);
		}
	}
}