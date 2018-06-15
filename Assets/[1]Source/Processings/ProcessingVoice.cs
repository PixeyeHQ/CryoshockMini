/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/9/2018 12:05 PM
================================================================*/


namespace Homebrew
{
	public class ProcessingVoice : ProcessingBase, IMustBeWipedOut, IReceive<SignalKilled>
	{
		private int counter;
		private Timer timer;

		public ProcessingVoice()
		{
			timer = new Timer(() => counter = 0, 0.75f);
		}


		protected override void OnDispose()
		{
			timer.Kill();
			timer = null;
		}

		public void HandleSignal(SignalKilled arg)
		{
			if (arg.tag != Tag.GroupEnemies) return;

			counter++;
			var t = 0.75f;
			if (counter == 2)
				Toolbox.Get<FactorySounds>().Spawn(Tag.SoundVoice, 1, 0);
			else if (counter == 3)
			{
				Toolbox.Get<FactorySounds>().Spawn(Tag.SoundVoice, 1, 1);
				t = 1;
			}
			else if (counter >= 4)
			{
				Toolbox.Get<FactorySounds>().Spawn(Tag.SoundVoice, 1, 2);

				counter = 0;
			}

			timer.Restart(t);
		}
	}
}