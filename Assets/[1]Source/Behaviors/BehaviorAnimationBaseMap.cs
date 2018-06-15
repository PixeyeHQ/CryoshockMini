/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 7:27 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public abstract class BehaviorAnimationBaseMap : Behavior, ITick
	{
		[Bind] protected DataAnimation dataAnimation;
		[Bind(From.Object)] protected Animator animator;
		protected bool overriding;

		private AnimatorOverrideController aoc;


		protected override void Setup()
		{
	 
			aoc = new AnimatorOverrideController(animator.runtimeAnimatorController);		 
			animator.runtimeAnimatorController = aoc;
			animator.Initialize(actor);
		}

		public void ChangeAnimationController(RuntimeAnimatorController controller)
		{
			animator.End();
 
			animator.runtimeAnimatorController = controller;
			animator.Initialize(actor);
		}

		public override void OnTick()
		{
			Map();
			if (dataAnimation.animationState != TagAnimations.NONE && overriding == false)
				animator.Play(dataAnimation.animationState.AsString(), 0, 0);

			dataAnimation.animationState = TagAnimations.NONE;
		}

		public void PlayAnimation(TagAnimations anim, bool overriding = false)
		{
			this.overriding = overriding;
			animator.Play(anim.AsString(), 0, 0);
		}

		protected abstract void Map();
	}
}