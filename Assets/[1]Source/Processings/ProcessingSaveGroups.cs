/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 10:50 PM
================================================================*/


namespace Homebrew
{
	public class ProcessingSaveGroups : ProcessingBase, IMustBeWipedOut
	{
		[GroupBy(Tag.GroupEnemies), GroupExclude(Tag.StateDead)]
		public Group groupEnemies;

		[GroupBy(Tag.ObjectSpawnerMobs)] public Group groupSpawners;

		public ProcessingSaveGroups()
		{
			Toolbox.Get<DataCryoshockGameSession>().spawners = groupSpawners.actors;
			Toolbox.Get<DataCryoshockGameSession>().enemies = groupEnemies.actors;
		}
	}
}