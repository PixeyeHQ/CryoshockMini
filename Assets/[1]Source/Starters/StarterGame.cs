/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 10:44 PM
================================================================*/


using DG.Tweening;

namespace Homebrew
{
	public class StarterGame : Starter
	{
		protected override void Setup()
		{
			
			Toolbox.Get<DataCryoshockGameSession>().score = 0;

			Toolbox.Add<ProcessingVoice>();
			Toolbox.Add<ProcessingSaveGroups>();
			Toolbox.Add<ProcessingCameraShake>();
			Toolbox.Add<ProcessingParallax>();
			Toolbox.Add<ProcessingScore>();
			Toolbox.Add<ProcessingGame>();

			Toolbox.Get<ProcessingSceneLoad>().sceneClosing = CloseScene;

		}

		void CloseScene()
		{
			ProcessingTimer.Default.Dispose();
			DOTween.KillAll();
		}
	}
}