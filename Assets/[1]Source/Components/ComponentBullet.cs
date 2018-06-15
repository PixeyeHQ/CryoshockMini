/*===============================================================
Product:    CryoshockMini
Developer:  Dimitry Pixeye - info@pixeye,games
Company:    Homebrew
Date:       6/9/2018 8:36 AM
================================================================*/

 
namespace Homebrew{
public class ComponentBullet : MonoCached, ITick
{

	public float timerDestroy;
	
	public override void Tick()
	{
		timerDestroy -= Time.DeltaTime;
	    if (timerDestroy<=0) HandleDestroyGO();
	}

	public override void OnDisable()
	{
		base.OnDisable();
		timerDestroy = 1.0f;
	}
}
}