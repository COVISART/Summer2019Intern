using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void CloseApp()
    {
        Application.Quit();
        Debug.Log("CloseApp Trigered");
    }

    public void LoadLevel(int scene)
    {
        StartCoroutine(LoadYourAsyncScene(scene));
    }

    IEnumerator LoadYourAsyncScene(int scene)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        var asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {

            yield return null;
        }
    }
}
