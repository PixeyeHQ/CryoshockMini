/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/8/2018 5:23 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class ProcessingParallax : ProcessingBase, IMustBeWipedOut, ITick
	{
		[GroupBy(Tag.GroupPlayers)] private Group players;
		[GroupBy(Tag.GroupParallax)] private Group parallaxBg;


		public void Tick()
		{
			if (players.length==0) return;
			var playerPosX = players.actors[0].selfTransform.position.x;
			var delta = playerPosX / 1.3f;
			parallaxBg.actors[0].selfTransform.position = new Vector3(-delta * 0.02f, 0, 0);
		}
	}
}