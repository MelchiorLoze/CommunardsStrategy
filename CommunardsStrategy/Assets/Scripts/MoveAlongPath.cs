using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongPath : MonoBehaviour
{

    public float moveSpeed = 2f;
    private Transform target;
    private int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = Waypoint.waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
        
        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(!(waypointIndex >= Waypoint.waypoints.Length - 1))
        {
            waypointIndex++;
            target = Waypoint.waypoints[waypointIndex];
        }
    }
}
