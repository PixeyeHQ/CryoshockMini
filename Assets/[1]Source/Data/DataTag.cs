/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/6/2018 8:08 PM
================================================================*/


namespace Homebrew
{
	[System.Serializable]
	public struct DataTag
	{
		[TagFilter(typeof(Tag))] public int id;
	}
}