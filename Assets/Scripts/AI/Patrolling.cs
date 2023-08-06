using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed;
    
    private int current = 0;

    // Update is called once per frame
    void Update()
    {
        if (transform.position != waypoints[current].position)
        {
            // Gerakan ke waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].position, speed * Time.deltaTime);
        }
        else
        {
            // Rotasi ke waypoint berikutnya
            current = (current + 1) % waypoints.Length;
            RotateTowardsNextWaypoint();
        }
    }

    private void RotateTowardsNextWaypoint()
    {
        // Mendapatkan arah ke waypoint berikutnya
        Vector3 direction = (waypoints[current].position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // Mengubah rotasi hanya pada sumbu y (untuk menghadap ke arah waypoint)
        transform.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
    }
}