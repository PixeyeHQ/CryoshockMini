//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	public class ProcessorAnimations : Processor
	{

		public Group<ComponentAnimations> groupOfAnimations;

		public ProcessorAnimations()
		{
			groupOfAnimations.onAdd += AwakeInGroupOfAnimations;
		}

		void AwakeInGroupOfAnimations(in ent entity)
		{
			var animator = entity.Get<Animator>();
			animator.runtimeAnimatorController = entity.ComponentAnimations().source;
		}

	}
}