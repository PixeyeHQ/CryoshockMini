/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/7/2018 1:28 PM
================================================================*/

 
using DG.Tweening;
using UnityEngine;

namespace Homebrew
{
	public class ProcessingCameraShake : ProcessingBase, IReceive<SignalCameraShake> , IMustBeWipedOut
	{
		private Tween twShakeFromShootCamera;
		private Tween twShakeAverage;
		private Tween twShakeStrong;
		private Tween twShakeVeryStrong;

		public ProcessingCameraShake()
		{
			
			var camera = Camera.main;
			twShakeFromShootCamera = camera.DOShakePosition(1.0f, 0.0033f)
				.Pause()
				.SetAutoKill(false)
				.OnKill(() => twShakeFromShootCamera = null);

			twShakeAverage = DOTween.Sequence()
				.Append(camera.DOShakePosition(1.0f, 0.0036f))
				.Join(camera.DOShakeRotation(1.0f, 0.002f))
				.Pause()
				.SetAutoKill(false)
				.OnKill(() => twShakeAverage = null);

			twShakeStrong = DOTween.Sequence()
				.Append(camera.DOShakePosition(1.0f, 0.008f))
				.Join(camera.DOShakeRotation(1.0f, 0.004f))
				.Pause()
				.SetAutoKill(false)
				.OnKill(() => twShakeStrong = null);

			twShakeVeryStrong = DOTween.Sequence()
				.Append(camera.DOShakePosition(1.0f, 0.02f))
				.Join(camera.DOShakeRotation(1.0f, 0.01f))
				.Pause()
				.SetAutoKill(false)
				.OnKill(() => twShakeVeryStrong = null);	
		}
	 
		protected override void OnDispose()
		{
			twShakeFromShootCamera.Kill();
			twShakeAverage.Kill();
			twShakeStrong.Kill();
			twShakeVeryStrong.Kill();
		}

		public void HandleSignal(SignalCameraShake arg)
		{
			if (arg.strength == 0)
				twShakeAverage.Restart();
			else if (arg.strength == 1)
				twShakeStrong.Restart();
			else if (arg.strength == 2)
				twShakeVeryStrong.Restart(); 
		}
	}
}