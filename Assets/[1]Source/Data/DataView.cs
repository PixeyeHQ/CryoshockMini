/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 10:26 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class DataView : IData, ISetup
	{
		private SpriteRenderer rendererActor;
		public MaterialPropertyBlock matPropBlock;

		public void Setup(Actor actor)
		{
			rendererActor = actor.Get<SpriteRenderer>("view");

			matPropBlock = new MaterialPropertyBlock();
			rendererActor.GetPropertyBlock(matPropBlock);
			matPropBlock.SetFloat("_ToggleThreshold", 0);
			SetPropertyBlock();
		}

		public void SetPropertyBlock()
		{
			rendererActor.SetPropertyBlock(matPropBlock);
		}

		public void Dispose()
		{
			rendererActor = null;
			matPropBlock = null;
		}
	}
}