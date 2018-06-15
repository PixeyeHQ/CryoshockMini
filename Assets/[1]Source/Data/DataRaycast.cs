/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 9:08 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class DataRaycast : IData
	{
		public RaycastHit2D hit;
		public RaycastHit2D[] hits = new RaycastHit2D[4];
		public int amount;
		
		public void Dispose()
		{
			hits = new RaycastHit2D[0];
		}
	}
}