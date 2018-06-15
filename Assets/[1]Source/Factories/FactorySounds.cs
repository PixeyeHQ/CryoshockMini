/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/9/2018 11:37 AM
================================================================*/


using System.Collections.Generic;
using UnityEngine;

namespace Homebrew
{
	[CreateAssetMenu(fileName = "FactorySounds", menuName = "Factories/FactorySounds")]
	public class FactorySounds : Factory
	{
		public List<Node> nodes = new List<Node>();
		public GameObject prefabSound;
		[SerializeField] protected Dictionary<int, List<AudioClip>> dict;


		private void OnEnable()
		{
			dict = new Dictionary<int, List<AudioClip>>();
			for (var i = 0; i < nodes.Count; i++)
			{
				dict.Add(nodes[i].tag, nodes[i].sources);
			}
		}

		public void Spawn(int tag, float volume = 0.2f, int id = -1)
		{
		 
			var clip = id == -1 ? dict[tag].ReturnRandom() : dict[tag][id];
			var go = this.Populate<AudioSource>(Pool.Audio, prefabSound);
			go.clip = clip;
			go.volume = volume;
			go.Play();
			Timer.Add(clip.length, () => ProcessingGoPool.Default.Despawn(Pool.Audio, go.gameObject));
		}

		[System.Serializable]
		public class Node
		{
			[TagFilter(typeof(Tag))] public int tag;
			public List<AudioClip> sources = new List<AudioClip>();
		}
	}
}