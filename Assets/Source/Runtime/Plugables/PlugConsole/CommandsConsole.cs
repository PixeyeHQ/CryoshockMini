//   Project : Actors
//  Contacts : Pixeye - ask@pixeye.games 

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	public abstract class CommandsConsole : ScriptableObject
	{

		[Bind]
		public string Help()
		{
			return Toolbox.Get<ProcessorConsole>().Help();
		}

	}
}