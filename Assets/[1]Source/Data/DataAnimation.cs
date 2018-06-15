/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 7:29 PM
================================================================*/


namespace Homebrew
{
	[System.Serializable]
	public class DataAnimation : IData
	{
		public TagAnimations animationState = TagAnimations.NONE;

		public void Dispose()
		{
		}
	}
}