using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

    private Transform target;
    private int wayPointIndex = 0;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target.position, enemy.speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        //resets the speed back to normal
        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        if (wayPointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wayPointIndex++;
        target = Waypoints.points[wayPointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
