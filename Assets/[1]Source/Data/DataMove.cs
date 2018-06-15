/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 6:22 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	[System.Serializable]
	public class DataMove : IData
	{
		public float spdMax = 2;
		public float spdAccelerate = 1;
		public float jumpForce = 50;
		public float face = 1;
		
		[HideInInspector] public float spdOffset;
		[HideInInspector] public float faceCache;
		[HideInInspector] public float faceOverride;
		[HideInInspector] public Vector2 input;
		[HideInInspector] public Vector2 velocity;


		public void Dispose()
		{
		}
	}
}