/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 8:07 PM
================================================================*/


using System.Collections.Generic;
using UnityEngine;

namespace Homebrew
{
	public class ComponentTag : MonoBehaviour
	{
		public List<DataTag> tags = new List<DataTag>();
		private HashSet<int> hash = new HashSet<int>();

		private void Awake()
		{
			for (int i = 0; i < tags.Count; i++)
			{
				hash.Add(tags[i].id);
			}
		}

		public bool CanBeObserved(int tag)
		{
			return hash.Contains(tag);
		}
	}

	public static class FrameworkExtensions
	{
		public static bool HasTag(this RaycastHit2D o, int tag)
		{
			var componentTags = o.collider.GetComponent<ComponentTag>();
			if (componentTags == null) return false;
			return componentTags.CanBeObserved(tag);
		}

  
		public static bool HasTag(this Collider2D o, int tag)
		{
			var componentTags = o.GetComponent<ComponentTag>();
			if (componentTags == null) return false;
			return componentTags.CanBeObserved(tag);
		}

		public static bool HasTag(this Collider2D o, List<DataTag> colliderTags)
		{
			var componentTags = o.GetComponent<ComponentTag>();
			if (componentTags == null) return false;

                
			for (var i = 0; i < colliderTags.Count; i++)
			{
				var t = colliderTags[i].id;
				if (!componentTags.CanBeObserved(t)) return false;
			 
			}

			return true;
		}

		public static Actor GetActor(this Collider2D o, int id)
		{
			if (o == null) return null;
			var componentTags = o.GetComponent<ComponentTag>();
			if (componentTags == null) return null;


			for (var i = 0; i < componentTags.tags.Count; i++)
			{
				var t = componentTags.tags[i];
				if (t.id == id)
				{
					var actor = componentTags.GetComponentInParent<Actor>();
					return actor;
				}
			}

			return null;
		}

	 
	}
}