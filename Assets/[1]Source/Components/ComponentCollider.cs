/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/8/2018 4:35 PM
================================================================*/


using System.Collections.Generic;
using UnityEngine;

namespace Homebrew
{
	public class ComponentCollider : MonoBehaviour
	{
		private Actor actor;
        
		public List<DataTag> filterTags = new List<DataTag>();
		
		private void Awake()
		{
			actor = GetComponentInParent<Actor>();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.HasTag(filterTags))
			actor.SignalDispatch(new SignalTriggerEnter {other = other});
		}
	}
}