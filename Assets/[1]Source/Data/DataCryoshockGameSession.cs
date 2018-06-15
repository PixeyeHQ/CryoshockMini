/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 5:14 PM
================================================================*/


using System.Collections.Generic;
using UnityEngine;

namespace Homebrew
{
	[CreateAssetMenu(fileName = "DataCryoshockGameSession", menuName = "Data/DataCryoshockGameSession")]
	public class DataCryoshockGameSession : DataGame
	{
		public List<Actor> spawners = new List<Actor>();
		public List<Actor> enemies = new List<Actor>();
		public int score;
	}
}