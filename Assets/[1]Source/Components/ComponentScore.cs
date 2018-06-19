/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/8/2018 7:51 PM
================================================================*/


using DG.Tweening;
using TMPro;
 

namespace Homebrew
{
	public class ComponentScore : MonoCached, IReceive<SignalChangeScore>
	{
		public TextMeshProUGUI label;

		public override void OnEnable()
		{
			if (state.HasState(EntityState.OnHold)) return;
			base.OnEnable();
			ProcessingSignals.Default.Add(this);
		}

		public override void OnDisable()
		{
			base.OnDisable();
			ProcessingSignals.Default.Remove(this);
		}

		public void HandleSignal(SignalChangeScore arg)
		{
			Toolbox.Get<DataCryoshockGameSession>().score++;
			label.text = Toolbox.Get<DataCryoshockGameSession>().score.ToString();
			label.rectTransform.DOShakePosition(0.5f,0.02f);
		}
	}
}