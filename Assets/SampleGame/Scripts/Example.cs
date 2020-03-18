using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine;
public class Example
{
    // adds a menu item which gives a brief summary of currently open Scenes
    [MenuItem("SceneExample/Scene Summary")]
    public static void ListSceneNames()
    {
        string output = "";
        if (SceneManager.sceneCount > 0)
        {
            for (int n = 0; n < SceneManager.sceneCount; ++n)
            {
                Scene scene = SceneManager.GetSceneAt(n);
                output += scene.name;
                output += scene.isLoaded ? " (Loaded, " : " (Not Loaded, ";
                output += scene.isDirty ? "Dirty, " : "Clean, ";
                output += scene.buildIndex >= 0 ? " in build)\n" : " NOT in build)\n";
            }
        }
        else
        {
            output = "No open Scenes.";
        }
        EditorUtility.DisplayDialog("Scene Summary", output, "Ok");
    }
}