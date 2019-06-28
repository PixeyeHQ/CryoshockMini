//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using UnityEngine;

namespace Pixeye.Source
{
	struct SegmentAmmo
	{
		public SpriteRenderer renderer;
		public Transform source;
		public Vector3 position;
		public float blinkTime;
		public float speed;
		public float lifeTime;
		public int blinkStage;
		
	}
}