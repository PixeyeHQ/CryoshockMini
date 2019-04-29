//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using UnityEngine;

namespace Pixeye
{
	public static class Anim
	{

		public static readonly int paramInput = Animator.StringToHash("Input");

		public static readonly int IDLE = Animator.StringToHash("IDLE");
		public static readonly int MOVE = Animator.StringToHash("MOVE");
		public static readonly int JUMP = Animator.StringToHash("JUMP");

	}
}