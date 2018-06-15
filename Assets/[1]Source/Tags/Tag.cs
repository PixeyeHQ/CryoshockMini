/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 8:09 PM
================================================================*/


namespace Homebrew
{
	public static class Tag
	{
		[TagField(categoryName = "Colliders")] public const int ColliderWall = 0;
		[TagField(categoryName = "Colliders")] public const int ColliderHit = 1;
		[TagField(categoryName = "Colliders")] public const int ColliderInteract = 2;
	 
		
		[TagField(categoryName = "Groups")] public const int GroupEnemies = 100;
		[TagField(categoryName = "Groups")] public const int GroupPlayers = 101;
		[TagField(categoryName = "Groups")] public const int GroupTeleports = 102;
		[TagField(categoryName = "Groups")] public const int GroupParallax = 103;
		[TagField(categoryName = "Groups")] public const int GroupWeapon = 104;
		
		[TagField(categoryName = "States")] public const int StateRage = 200;
		[TagField(categoryName = "States")] public const int StateBlockMove = 201;
		[TagField(categoryName = "States")] public const int StateDead = 202;
		[TagField(categoryName = "States")] public const int StateDrifting = 203;
		[TagField(categoryName = "States")] public const int StateReloading = 204;
		[TagField(categoryName = "States")] public const int StateBlockTurn = 205;
		[TagField(categoryName = "States")] public const int StateInTheAir = 206;
		[TagField(categoryName = "States")] public const int StateGod = 207;
		
		[TagField(categoryName = "Objects")] public const int ObjectSpawnerMobs = 300;
		[TagField(categoryName = "Objects")] public const int ObjectSpawnerGuns = 301;
		[TagField(categoryName = "Objects")] public const int ObjectBullet = 302;
		
		[TagField(categoryName = "Signals")] public const int SignalDrift = 400;
		
		[TagField(categoryName = "Sounds")] public const int SoundShootGun = 500;
		[TagField(categoryName = "Sounds")] public const int SoundShootShotGun = 501;
		[TagField(categoryName = "Sounds")] public const int SoundVoice = 502;
		[TagField(categoryName = "Sounds")] public const int SoundShootHit = 503;
		[TagField(categoryName = "Sounds")] public const int SoundAlarm = 504;
		[TagField(categoryName = "Sounds")] public const int SoundTakeGun = 505;
	}
}