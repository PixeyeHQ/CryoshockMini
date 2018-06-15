/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/8/2018 1:38 PM
================================================================*/


using DG.Tweening;
using UnityEngine;

namespace Homebrew
{
	public class DecorateInteractiveObject : Behavior, ITick
	{
		private Tween animateObject;
		private Tween animateBlink;
		private Color colorBlink = new Color(0, 0, 0, 1);
		private Color colorCached;

		[Bind] private DataView dataView;

		protected override void Setup()
		{
			animateObject = actor.selfTransform
				.DOMoveY(0.085f, 1f)
				.SetEase(Ease.InOutSine)
				.SetLoops(-1, LoopType.Yoyo)
				.SetRelative(true)
				.SetAutoKill(false)
				.Pause();


			colorCached = dataView.matPropBlock.GetColor("_BlinkColor");

			animateBlink = DOTween.To(() => colorBlink, x => colorBlink = x, new Color(0.2f, 0.2f, 0.2f, 1), 1.0f)
				.SetEase(Ease.InOutSine)
				.SetLoops(-1, LoopType.Yoyo)
				.SetRelative(true)
				.SetAutoKill(false)
				.Pause();
		}

		public override void OnTick()
		{
		 
			dataView.matPropBlock.SetColor("_BlinkColor", colorBlink);
			dataView.SetPropertyBlock();
		}

		protected override void OnEnable()
		{
			animateObject.Restart();
			animateBlink.Restart();
		}

		protected override void OnDisable()
		{
			animateObject.Pause();
			animateBlink.Pause();
			dataView.matPropBlock.SetColor("_BlinkColor", colorCached);
		}

		protected override void OnDispose()
		{
			animateObject.Kill();
			animateObject = null;
		}
	}
}