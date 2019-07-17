//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games


using UnityEngine;
using Pixeye.Framework;

namespace Pixeye.Source
{
   static class DataBase 
    {
        public static class Prefabs
        {

	        public static GameObject Unit = Box.Load<GameObject>("Obj Unit");
	        public static GameObject Sprite = Box.Load<GameObject>("Obj Sprite");
        }
    }
}