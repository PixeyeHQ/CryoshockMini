/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/8/2018 4:50 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class DecorateDamageBlink : Behavior, IReceive<SignalDamage>
	{
		public void HandleSignal(SignalDamage arg)
		{
	 
			
			if (Random.value>0.6f)
				Toolbox.Get<FactoryFx>().SpawnBlood(actor.selfTransform.position+new Vector3(Random.Range(-0.2f,0.2f),Random.Range(-0.2f,0.2f)));
		 
			var dataView = actor.Get<DataView>();
			dataView.matPropBlock.SetFloat("_Blink", 1);
			dataView.SetPropertyBlock();
			Timer.Add(0.1f, () =>
			{
				 
				dataView.matPropBlock.SetFloat("_Blink", 0);
				dataView.SetPropertyBlock();
			});
			
			
		}
	}
}