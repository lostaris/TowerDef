using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    private int startLives = 20;

    public static int Rounds;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;

        Rounds = 0;
    }

}
