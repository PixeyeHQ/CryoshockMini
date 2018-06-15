/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 9:13 PM
================================================================*/

 
namespace Homebrew
{
	public class BehaviorFlipWalls : Behavior, ITick
	{
		[Bind] private DataRaycast data;
	//	private bool conditionDead;
		public override void OnTick()

		{
		//	if (conditionDead) return;
			if (UnityEngine.Time.frameCount % 5 != 0) return;
			for (var i = 0; i < data.amount; i++)
			{
				var hit = data.hits[i];

				if (hit.HasTag(Tag.ColliderWall))
				{
					Get<DataMove>().face *= -1;

					return;
				}
			}
		}

		public override void OnTagsChanged()
		{
		//	conditionDead = actor.tags.Contain(Tag.StateDead);
		}
	}
}