/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 7:14 PM
================================================================*/


using System.Collections.Generic;

namespace Homebrew
{
	public enum TagAnimations
	{
		NONE = -1,
		MOVE = 0,
		FALL = 1,
		JUMP = 2,
		STOP = 3,
		LOCOMOTION = 4
	}
	
	public static class AnimationExtensions
	{
		private static Dictionary<int, string> states;

		static AnimationExtensions()
		{
			states = new Dictionary<int, string>();
			foreach (var value in System.Enum.GetValues(typeof(TagAnimations)))
			{
				states.Add((int) value, System.Enum.GetName(typeof(TagAnimations), value));
			}
		}

		public static string AsString(this TagAnimations state)
		{
			return states[(int) state];
		}
	}
	
}