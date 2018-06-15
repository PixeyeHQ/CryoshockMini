/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/8/2018 4:54 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class DecorateHealthHelmet : Behavior, IReceive<SignalDamage>
	{
		private Color colGreen = new Color(0.27f, 0.8f, 0, 1);
		private Color colYellow = new Color(0.8f, 0.8f, 0, 1);
		private Color colRed = new Color(0.8f, 0.0f, 0.1f, 1);


		protected override void Setup()
		{
		}

		public void HandleSignal(SignalDamage arg)
		{
			var hp = Get<DataHealth>().HP;
			Color col = colGreen;

			if (hp == 2) col = colYellow;
			else if (hp <= 1) col = colRed;

			var dataView = Get<DataView>();
			dataView.matPropBlock.SetColor("_ReplaceColor", col);
			dataView.SetPropertyBlock();
			
			
		}
	}
}