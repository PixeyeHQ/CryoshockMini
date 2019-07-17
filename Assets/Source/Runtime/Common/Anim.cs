//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using UnityEngine;

namespace Pixeye.Source
{
	public static class Anim
	{

		public static readonly int PARAM_X = Animator.StringToHash("X");
		public static readonly int PARAM_Y = Animator.StringToHash("Y");

		
		public static readonly int IDLE = Animator.StringToHash("IDLE");
		public static readonly int MOVE = Animator.StringToHash("MOVE");
		public static readonly int JUMP = Animator.StringToHash("JUMP");

	}
}