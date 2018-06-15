/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 10:46 PM
================================================================*/


using System.Collections.Generic;

namespace Homebrew
{
	public class ActorTag : Actor
	{
		[FoldoutGroup("Setup")] public List<DataTag> actorTags = new List<DataTag>();

		protected override void Setup()
		{
			for (var i = 0; i < actorTags.Count; i++)
			{
				tags.Add(actorTags[i].id);
			}
		}
	}
}