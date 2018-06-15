/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/7/2018 1:15 PM
================================================================*/


using System.Collections.Generic;
using UnityEngine;

namespace Homebrew
{
	[System.Serializable]
	public class DataWeapon : IData
	{
		[SerializeField]
		private List<BlueprintWeapon> weapon = new List<BlueprintWeapon>();

		public BlueprintWeapon GetWeapon(int id)
		{
			return weapon[id];
		}
		
		public void Dispose()
		{
			weapon.Clear();
		}
	}
}