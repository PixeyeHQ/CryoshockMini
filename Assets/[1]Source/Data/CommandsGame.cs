/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 5:18 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	[CreateAssetMenu(fileName = "CommandsGame", menuName = "Commands/CommandsGame")]
	public class CommandsGame : CommandsConsole
	{
		[Bind]
		public void Spawn(int id)
		{
			var go = Toolbox.Get<FactorySpawner>().Spawn(id);
			go.position = Toolbox.Get<DataCryoshockGameSession>().spawners[0].selfTransform.position;
		}
	}
}