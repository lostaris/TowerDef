using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new EnemyStats", menuName = "EnemyStats")]
public class EnemyStats : ScriptableObject
{

    public new string name;

    public GameObject model;
    public Enemy enemy;
    public Material mat;
    public GameObject deathEffect;

    public float startSpeed;
    public float startHealth;
    public int worth;

}
