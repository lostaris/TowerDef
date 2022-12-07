using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject ui;
    public string menu = "MainMenu";

    public SceneFader sceneFader;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            //pausing the game
            Time.timeScale = 0f;
        } else
        {
            //unpausing the game
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        // using toggle to set time going again
        Toggle();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Debug.Log("go to menu");
        Time.timeScale = 1f;
        //SceneManager.LoadScene(menu);
        sceneFader.FadeTo(menu);
    }
}
