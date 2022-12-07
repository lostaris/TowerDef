using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{

    public Text roundsText;
    void Awake()
    {
        //roundsText.text = PlayerStats.Rounds.ToString();
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText ()
    {
        roundsText.text = "0";
        int round = 0;
        while (round < PlayerStats.Rounds)
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(.5f);
        }

    }

}
