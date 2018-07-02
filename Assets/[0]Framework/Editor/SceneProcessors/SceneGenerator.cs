using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine;
 
 
[InitializeOnLoad]
public class SceneGenerator  {
 
 
    static SceneGenerator()
    {
        EditorSceneManager.newSceneCreated += SceneCreating;
    }
 
 
	public static void SceneCreating(Scene scene, NewSceneSetup setup, NewSceneMode mode)
	{
       
		if (Camera.main == null) return;

		var camGO = Camera.main.gameObject;
		var light = GameObject.Find("Directional Light");
		if (light != null)
		{
			GameObject.DestroyImmediate(light.gameObject);
		}
		GameObject.DestroyImmediate(camGO);
		new GameObject("[SETUP]");
		var s = new GameObject("[SCENE]");
		var d = new GameObject("Dynamic");
		d.transform.parent = s.transform;
		Debug.Log("New scene created!");
 
	}
   
 
}