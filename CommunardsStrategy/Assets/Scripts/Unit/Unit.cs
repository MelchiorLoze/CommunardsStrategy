using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class Unit : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void Start()
    {
        // Used to find a target every O.5 seconds
        InvokeRepeating("GetTarget", 0f, 0.1f);

        // Used to attack at the right firerate
        InvokeRepeating("Attack", 0f, fireRate);
    }

    // Get the closest enemy that is in range
    protected virtual void GetTarget()
    {
        // if target already selected
        if (target != null)
        {
            // verifies if it is still in range
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (isTargetFocusable(target, distanceToTarget))
                return;
            else
                target = null;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        // finds the closest enemy
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        Unit potentielTarget = nearestEnemy.GetComponent<Unit>();
        if (nearestEnemy != null && isTargetFocusable(potentielTarget, shortestDistance))
            target = potentielTarget;
        else
            target = null;
        
    }

    // returns True if the target can be focused on (ie: in range and in field of vision)
    protected bool isTargetFocusable(Unit target, float distanceToTarget)
    {
        Vector3 forward = transform.right;
        Vector2 targetVector = target.transform.position - transform.position;
        float angle = Vector2.Angle(forward, targetVector);

        return distanceToTarget <= range && angle <= (viewAngle / 2);
    }

    // Attack the target
    protected void Attack()
    {
        if (target != null)
            target.TakeDamage(damage);
    }

    // Update is called once per frame
    public virtual void Update()
    {
    }

    // Take damage
    protected void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    // Function called when the unit is dead
    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    // Function to draw the range sphere
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.87f, 0f, 0f);
        Gizmos.DrawWireSphere(transform.position, range);

        Handles.color = new Color(0.87f, 0f, 0f, 0.2f);

        float desiredAngle = Mathf.Deg2Rad * (viewAngle / 2);
        Vector3 forward = transform.right;
        float x = (Mathf.Cos(desiredAngle) * forward.x) - (Mathf.Sin(desiredAngle) * forward.y);
        float y = (Mathf.Sin(desiredAngle) * forward.x) + (Mathf.Cos(desiredAngle) * forward.y);

        // draws the field of vision of the Unit
        Handles.DrawSolidArc(transform.position, -new Vector3(0, 0, 1), new Vector3(x, y, 0), viewAngle, range);
    }

    // rotates the gameObject towards the target
    protected void RotateTowardsTarget(Transform target)
    {
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    }

    public int health = 1;
    public int damage = 1;
    public float fireRate = 1;
    public float range = 1;
    public int viewAngle = 360;
    public string enemyTag;
    public float rotationSpeed = 0.5f;

    protected Unit target = null;
}