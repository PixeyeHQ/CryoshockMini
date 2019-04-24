//   Project : Actors
//  Contacts : Pixeye - ask@pixeye.games 

using UnityEngine;

namespace Pixeye.Framework
{
    [CreateAssetMenu(fileName = "GameSession", menuName = "Actors/Add/Data/GameSession")]
	public class GameSession : DataSession, IKernel
    {
        public static GameSession Default => Toolbox.Get<GameSession>();
    }
}
