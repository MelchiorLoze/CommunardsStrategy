using UnityEngine;

public class Enemy : Unit
{
    public int moneyOnDeath = 100;
    public float moveSpeed = 1;

    private Transform waypointTarget;
    private int waypointIndex = 0;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        waypointTarget = Waypoint.waypoints[waypointIndex];
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (target == null && waypointTarget != null)
        {
            // If no target is found, moves to next waypoint
            MoveToNextWaypoint();
            if (waypointTarget != null)
                RotateTowardsTarget(waypointTarget.transform);
        }
        else if (target != null)
            RotateTowardsTarget(target.transform);
        // In both cases rotates the unit towards either the waypoint or the target
    }

    // Moves to the next waypoint according to the move speed
    void MoveToNextWaypoint()
    {
        Vector3 direction = waypointTarget.position - transform.position;
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, waypointTarget.position) <= 0.1f)
            GetNextWaypoint();
    }

    // Gets the next waypoint in the list
    void GetNextWaypoint()
    {
        if (waypointIndex < Waypoint.waypoints.Length - 1)
        {
            waypointIndex++;
            waypointTarget = Waypoint.waypoints[waypointIndex];
            RotateTowardsTarget(waypointTarget);
        }
        else
            waypointTarget = null;
    }

    // Function called when the unit is dead
    protected override void Die()
    {
        base.Die();
        BuildManager.instance.AddMoney(moneyOnDeath);
    }
}