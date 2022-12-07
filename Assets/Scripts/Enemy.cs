using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    public float startSpeed = 10f;
    public float startHealth = 100f;
    private float health;
    public int worth = 25;

    public GameObject deathEffect;

    [Header("unity stuff")]
    public Image healthBar;

    private bool isDead = false;

    private void Start()
    {
        health = startHealth;
        speed = startSpeed;
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
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

  
}
