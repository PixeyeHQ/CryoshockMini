/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/7/2018 1:16 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	[CreateAssetMenu(fileName = "BlueprintWeapon", menuName = "Blueprints/Weapon")]
	public class BlueprintWeapon : Blueprint
	{
		public GameObject prefab;
		public float spread;
		public int amountPerShot;
		public GameObject prefabBullet;
		public int shakeForce = 1;
		public float returnForce;
		public float speedIntial = 50;
		public Vector2 speedDrag;
		public float timeBeforeDestroy = 1;
		public AnimatorOverrideController animController;
		public string muzzleID;
		public float reloadTime;

		[TagFilter(typeof(Tag))] public int soundsTag;


		public void Shoot(Rigidbody2D rig, float side, Transform muzzle)
		{
			rig.AddForceAtPosition(new Vector2(-side * returnForce, 0), rig.transform.position);
			ProcessingSignals.Default.Send(new SignalCameraShake {strength = shakeForce});
			Toolbox.Get<FactorySounds>().Spawn(soundsTag);
			
			for (var i = 0; i < amountPerShot; i++)
			{
				var bullet = this.Populate(Pool.Projectiles, prefabBullet);
				bullet.position = muzzle.position;
				var bulletRig = bullet.GetComponent<Rigidbody2D>();
				bulletRig.drag = Random.Range(speedDrag.x, speedDrag.y);
				bulletRig.AddForce(new Vector2(side * speedIntial, Random.Range(-1f, 1f) * spread));
				bullet.GetComponent<ComponentBullet>().timerDestroy = timeBeforeDestroy;
			}
		}
	}
}