using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float startSpeed;
    private float startHealth;

    public float health;
    private int worth = 25;

    [HideInInspector]
    public GameObject deathEffect;
    [HideInInspector]
    public GameObject model;
    [HideInInspector]
    public EnemyStats enemyStats;

    [Header("unity stuff")]
    public Image healthBar;

    private bool isDead = false;
    
    private void Start()
    {
        LoadEnemy(enemyStats);
    }


    public void LoadEnemy (EnemyStats data)
    {
        
        /*GameObject visuals = Instantiate(data.model);
        //visuals.transform.SetParent(this.transform);
        visuals.transform.localPosition = Vector3.zero;
        visuals.transform.rotation = Quaternion.identity;*/

        this.health = enemyStats.startHealth;
        this.speed = enemyStats.startSpeed;
        this.worth = enemyStats.worth;
        this.deathEffect = enemyStats.deathEffect;
        this.model = enemyStats.model;
        Debug.Log("Enemy health=" + health);
    }


    public void TakeDamage (float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow (float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;
        PlayerStats.Money += worth;
        Vector3 pos = this.transform.position;
        Quaternion rot = transform.rotation;
        GameObject death = this.deathEffect;
        GameObject effect = (GameObject)Instantiate(death, pos, rot);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

  
}
