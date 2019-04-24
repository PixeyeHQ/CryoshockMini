//   Project : Actors
//  Contacts : Pixeye - ask@pixeye.games 

using UnityEngine;

namespace Pixeye.Framework
{
	[CreateAssetMenu(fileName = "GameSettings", menuName = "Actors/Add/Data/GameSettings")]
	public class GameSettings : DataSession, IKernel
	{

		public static GameSettings Default => Toolbox.Get<GameSettings>();

	}
}