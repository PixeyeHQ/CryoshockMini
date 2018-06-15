/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/9/2018 10:51 AM
================================================================*/


using DG.Tweening;
using UnityEngine;

namespace Homebrew
{
	public class ComponentSaw : MonoCached, ITick
	{
		private Transform obj;

		protected override void OnAwake()
		{
			obj = selfTransform.GetChild(0);

			selfTransform
				.DOBlendableMoveBy(new Vector3(1.3f, 0, 0), 3.0f)
				.SetEase(Ease.InOutQuad)
				.SetLoops(-1, LoopType.Yoyo)
				.SetAutoKill(false);

		}

		public override void Tick()
		{
			obj.localEulerAngles += new Vector3(0, 0, 480 * Time.DeltaTime);
			if (obj.localEulerAngles.z >= 360)
				obj.localEulerAngles = Vector3.zero;
		}
	}
}