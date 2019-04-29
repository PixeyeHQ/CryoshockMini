//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

using System;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	 
	
	public static class AnimatorGuide
	{
		public delegate void Task( in ent entity, ComponentAnimator cAnimator);
		
		public static void Player(in ent entity, ComponentAnimator cAnimator)
		{
			var cMotion = entity.ComponentMotion();
		//	Debug.Log(cAnimator.source.GetParameter(Anim.ParamInput).name);
			cAnimator.source.SetFloat(Anim.paramInput,Math.Abs(cMotion.velocity.x));
			
		}
 

	}

	 
	
	
}