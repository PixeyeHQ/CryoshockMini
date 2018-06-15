/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/9/2018 9:03 AM
================================================================*/


using UnityEngine;

namespace Homebrew
{
	public class ComponentMenu : MonoCached
	{
		public void HandleDiscord()
		{
			Application.OpenURL("https://discord.gg/SR5HaAu");
		}

		public void HandleTwitter()
		{
			Application.OpenURL("https://twitter.com/dimmPixeye/");
		}
		
		public void HandleGit()
		{
			Application.OpenURL("https://github.com/dimmpixeye/Actors-Unity3d-Framework/");
		}
		
	}
}