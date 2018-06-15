/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 5:18 PM
================================================================*/
 
using Homebrew;
using UnityEngine;

public class ActorEnemy : Actor, ITick, ITickFixed
{
	[FoldoutGroup("Setup"), SerializeField]
	private DataMove dataMove;
	[FoldoutGroup("Setup"), SerializeField]
	private DataHealth dataHealth;

	protected override void Setup()
	{
		Add(dataMove);
        Add(dataHealth);
		
		Add<DataView>();
		Add<DataRaycast>();
		Add<DataAnimation>();
 
		Add<BehaviorSense>();
		Add<BehaviorMove>();
		Add<BehaviorTurn>();
		Add<BehaviorRage>();
		Add<BehaviorDeath>();
    	Add<BehaviorFlipWalls>();
		Add<BehaviorGetDamage>();
    	Add<BehaviorTeleportMove>();
		Add<BehaviorAIProcessing>();
		Add<BehaviorAnimationMap>();

		Add<DecorateDamageBlink>();
		
		tags.Add(Tag.GroupEnemies);
	}


	public class BehaviorAnimationMap : BehaviorAnimationBaseMap
	{
		[Bind] private DataMove dataMove;

		private bool condition_fall;

		protected override void Map()
		{
			HandleFallAnimation();
		}

		private void HandleFallAnimation()
		{
			if (dataMove.velocity.y > 0.1f || dataMove.velocity.y < -0.1f)
			{
				dataAnimation.animationState = TagAnimations.FALL;
			}
		}
	}
	
 
	
	
}