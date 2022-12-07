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

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1/wave.rate);
        }

        waveNumber++;

        PlayerStats.Rounds++;
        
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}
