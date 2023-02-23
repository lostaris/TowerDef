using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive;

    //public Transform enemyPrefab;
    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveNumber = 0;

    public Text waveCoutdownText;

    public GameManager gameManager;

    private void Start()
    {
        EnemiesAlive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemiesAlive >0)
        {
            return;
        }

        if (waveNumber == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            Debug.Log("spawning a wave");
            StartCoroutine( SpawnWave() );
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCoutdownText.text = string.Format("{0:00.00}", countdown);
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveNumber];
        Debug.Log("wave number: " + waveNumber + " enemy should be: " + wave.count + " "+ wave.enemyStats.name);

        EnemiesAlive = wave.count;

        Enemy enemy = wave.enemyStats.enemy;
        enemy.enemyStats = wave.enemyStats;

        for (int i = 0; i < wave.count; i++)
        {
            
            //enemy.LoadEnemy(wave.enemyStats);
            SpawnEnemy(wave.enemyStats.enemy);
            Debug.Log("Spawning " + wave.enemyStats.name + " hp= " +wave.enemyStats.startHealth);
            yield return new WaitForSeconds(1/wave.rate);
        }

        waveNumber++;

        PlayerStats.Rounds++;
    }

    void SpawnEnemy(Enemy enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}
