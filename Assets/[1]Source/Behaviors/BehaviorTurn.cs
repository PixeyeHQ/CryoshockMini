/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/7/2018 8:14 AM
================================================================*/


using System;
using UnityEngine;

namespace Homebrew
{
	public class BehaviorTurn : Behavior, ITick
	{
		[Bind] private DataMove dataMove;

		private Transform view;


		protected override void Setup()
		{
			view = actor.selfTransform.GetChild(0).transform;
		}

		public override void OnTick()
		{
			if (dataMove.faceCache != dataMove.face)
			{
				view.localScale = new Vector3(dataMove.faceOverride == 0 ? dataMove.face : dataMove.faceOverride, 1, 1);
				dataMove.faceCache = dataMove.face;
			}
		}

	 
	}
}