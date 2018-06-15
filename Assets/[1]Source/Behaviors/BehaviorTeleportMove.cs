/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 9:07 PM
================================================================*/

 
namespace Homebrew
{
	public class BehaviorTeleportMove : Behavior, ITick
	{
		[Bind] private DataRaycast data;
		private bool condition_teleported;
		public override void OnTick()

		{
			if (UnityEngine.Time.frameCount % 5 != 0) return;
			if (condition_teleported) return;
			for (int i = 0; i < data.amount; i++)
			{
				var hit = data.hits[i];

				if (hit.HasTag(Tag.GroupTeleports))
				{
					Get<DataMove>().face *= -1;
					actor.selfTransform.position = hit.transform.GetChild(0).position;
					condition_teleported = true;
					Timer.Add(1f,()=>condition_teleported=false);
					return;
				}
			}
		}
	}
}