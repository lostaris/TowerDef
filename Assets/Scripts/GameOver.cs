using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    
    public string menu = "MainMenu";

    public SceneFader sceneFader;


    public void Retry()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Debug.Log("go to menu");
        //SceneManager.LoadScene(menu);
        sceneFader.FadeTo(menu);
    }
}
