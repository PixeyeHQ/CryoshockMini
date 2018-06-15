/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/7/2018 1:15 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	[CreateAssetMenu(fileName = "BlueprintHero", menuName = "Blueprints/Hero")]
	public class BlueprintHero : Blueprint
	{
		[FoldoutGroup("Setup global"), SerializeField]
		public DataWeapon dataWeapon;


		public override void Setup()
		{
			Add(dataWeapon);
		}
	}
}