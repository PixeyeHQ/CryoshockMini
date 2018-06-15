/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 10:41 PM
================================================================*/


using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Homebrew
{
	[CreateAssetMenu(fileName = "FactorySpawner", menuName = "Factories/FactorySpawner")]
	public class FactorySpawner : Factory
	{
		[SerializeField] private List<GameObject> prefabEnemies = new List<GameObject>();
		[SerializeField] private List<BlueprintWeapon> weapons = new List<BlueprintWeapon>();
		[SerializeField] private GameObject prefabPlayer;

		public override Transform Spawn(int id)
		{
			var prefab = prefabEnemies[id];
			return this.Populate(Pool.None, prefab);
		}

		public Transform SpawnPlayer()
		{
			return this.Populate(Pool.None, prefabPlayer);
		}

		public void SpawnWeapon(Vector3 pos, BlueprintWeapon currentWeapon)
		{
			var w = weapons
				.Except(weapons.Select(item => currentWeapon).Distinct()).ToList();

        
			var weapon = this.Populate(Pool.None, w.ReturnRandom().prefab, pos);
			weapon.transform.position = new Vector3(pos.x, pos.y, 0);
		}
	}
}