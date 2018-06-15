/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/8/2018 6:18 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	[System.Serializable]
	public class DataBloodFx : IData
	{
		public Sprite[] sprites;
		public GameObject prefab;
		public void Dispose()
		{
			sprites = new Sprite[0];
			prefab = null;
		}
	}
}