/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 10:24 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class BehaviorRage : Behavior
	{
		private bool conditionRaged;

		public override void OnTagsChanged()
		{
			var conditionRage = actor.tags.Contain(Tag.StateRage);

			if (conditionRage && !conditionRaged)
			{
				var data = Get<DataView>();
				data.matPropBlock.SetColor("_Color", new Color(1, 0, 100 / 255f, 1));
				data.SetPropertyBlock();
				conditionRaged = true;
			}
			else if (conditionRaged && !conditionRage)
			{
				var data = Get<DataView>();
				data.matPropBlock.SetColor("_Color", new Color(1, 1, 1, 1));
				conditionRaged = false;
			}
		}
	}
}