using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToload = "MainLevel";

    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(levelToload);
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
