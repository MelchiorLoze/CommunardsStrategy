using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    // Start is called before the first frame update
    public override void Start()
    {
        /* base.Start();
        waypointTarget = Waypoint.waypoints[waypointIndex]; */
    }

    // Update is called once per frame
    public override void Update()
    {
        /* base.Update();
        if (target == null)
            MoveToNextWaypoint(); */
    }

    void MoveToNextWaypoint()
    {
        Vector3 direction = waypointTarget.position - transform.position;
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, waypointTarget.position) <= 0.2f)
            GetNextWaypoint();
    }

    void GetNextWaypoint()
    {
        if (waypointIndex < Waypoint.waypoints.Length - 1)
        {
            waypointIndex++;
            waypointTarget = Waypoint.waypoints[waypointIndex];
        }
    }

    public float moveSpeed = 1;
    private Transform waypointTarget;
    private int waypointIndex = 0;
}