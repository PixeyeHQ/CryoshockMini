/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/7/2018 1:26 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	[System.Serializable]
	public class DataCurrentWeapon : IData
	{
		public BlueprintWeapon weapon;

		public void Dispose()
		{
			weapon = null;
		}
	}
}