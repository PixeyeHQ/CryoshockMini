/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/7/2018 1:55 PM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class AnimationStateTag : BaseStateMachineBehavior
	{
		public DataTag[] tags;


		private int[] groupAddRemove;
 

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
	 
			actor.tags.Add(groupAddRemove);
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
		{
			EndState();
		}

		void EndState()
		{
			actor.tags.Remove(groupAddRemove);
 
		}

		public override void End()
		{
			EndState();
		}

		protected override void OnSetup()
		{
			groupAddRemove = new int[tags.Length];
			for (var i = 0; i < tags.Length; i++)
				groupAddRemove[i] = tags[i].id;
		}
	}
}