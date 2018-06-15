/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/7/2018 7:35 AM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class ActorHero : Actor, ITick, ITickFixed
	{
		[FoldoutGroup("Setup"), SerializeField]
		private DataHealth dataHealth;

		[FoldoutGroup("Setup"), SerializeField]
		private DataMove dataMove;

		[FoldoutGroup("Setup"), SerializeField]
		private DataCurrentWeapon dataCurrentWeapon;

		protected override void Setup()
		{
			Add(dataCurrentWeapon);
			Add(dataMove);
			Add(dataHealth);

			Add<DataView>();
			Add<DataRaycast>();
			Add<DataAnimation>();

			Add<BehaviorDeath>();
			Add<BehaviorInput>();
			Add<BehaviorDrift>();
			Add<BehaviorTurn>();
			Add<BehaviorFire>();

			Add<BehaviorGrab>();
			Add<BehaviorMove>();
			Add<BehaviorJump>();
 
			Add<BehaviorGetDamage>();
			Add<BehaviorAnimationMap>();
			
	 
			Add<DecorateDamageBlink>();
			Add<DecorateHealthHelmet>();
			
			tags.Add(Tag.GroupPlayers);
			
		}


		public class BehaviorAnimationMap : BehaviorAnimationBaseMap, IReceive<SignalChangeWeapon>
		{
			[Bind] private DataMove dataMove;

			private bool conditionInAir;
			private int animator_inputX;

			public void HandleSignal(SignalChangeWeapon arg)
			{
				ChangeAnimationController(arg.blueprintWeapon.animController);
			}


			protected override void Setup()
			{
				base.Setup();
				animator_inputX = Animator.StringToHash("INPUT_X");
			}

			protected override void Map()
			{
				animator.SetFloat(animator_inputX, dataMove.velocity.x);

				CheckConditionInAir();
			}

			void CheckConditionInAir()
			{
				var absY = Mathf.Abs(dataMove.velocity.y);

				if (absY > 0.1f)
				{
					if (!conditionInAir)
					{
						conditionInAir = true;
						PlayAnimation(TagAnimations.JUMP, true);
					}
				}

				if (dataMove.velocity.y == 0)
				{
					if (conditionInAir)
					{
						Get<DataAnimation>().animationState = TagAnimations.LOCOMOTION;
						conditionInAir = false;
						overriding = false;
					}
				}
			}
		}
		
		
	}
}