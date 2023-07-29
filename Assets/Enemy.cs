using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavePointIndex = 0;

    private void Start()
    {
        target = WayPoints.waypoints[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    private void GetNextWayPoint()
    {
        if (wavePointIndex >= WayPoints.waypoints.Length - 1) 
        { 
            Destroy(gameObject); 
            return; 
        }
        wavePointIndex++;
        target = WayPoints.waypoints[wavePointIndex];
    }
}
