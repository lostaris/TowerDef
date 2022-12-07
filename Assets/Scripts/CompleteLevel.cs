using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{

    public string menu = "MainMenu";

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public SceneFader sceneFader;

    public void Menu ()
    {
        sceneFader.FadeTo(menu);
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }

}
