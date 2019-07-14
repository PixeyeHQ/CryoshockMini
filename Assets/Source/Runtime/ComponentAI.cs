
//  Project : game.cryoshockmini
// Contacts : Pix - ask@pixeye.games

 
using UnityEngine;
using Pixeye.Framework;
using System.Runtime.CompilerServices;
 
 
 

namespace Pixeye.Source
{
 
   sealed class ComponentAI
   {
	   public float speedMax;
	   public float direction;
	   public bool blockMovement;
   }
    
    
   #region HELPERS
   static partial class Components
    {
         
        public const string AI = "Pixeye.Source.ComponentAI";
    
        [RuntimeInitializeOnLoadMethod]
		static void ComponentAIInit()
		{
			Storage<ComponentAI>.Instance.Creator = () => { return new ComponentAI(); };
    	    Storage<ComponentAI>.Instance.DisposeAction = DisposeComponentAI;
		} 
       
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void DisposeComponentAI(in ent entity)
		{
		 	ref var component = ref Storage<ComponentAI>.Instance.components[entity.id];
		}
       
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ref ComponentAI ComponentAI(in this ent entity)
        {
            return ref Storage<ComponentAI>.Instance.components[entity.id];
        }
    }
    #endregion
}