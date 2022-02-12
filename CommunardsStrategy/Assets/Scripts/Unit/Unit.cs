using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void Start()
    {
        // Used to find a target every O.5 seconds
        InvokeRepeating("GetTarget", 0f, 0.5f);

        // Used to attack at the right firerate
        InvokeRepeating("Attack", 0f, fireRate);
    }

    // Get the closest enemy that is in range
    protected void GetTarget()
    {
        // if target already selected
        if (target != null)
        {
            // verifies if it is still in range
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToTarget > range)
                target = null;
            else
                return;
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

        if (nearestEnemy != null && shortestDistance <= range)
            target = nearestEnemy.GetComponent<Unit>();
        else
            target = null;
        
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
    }

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
    public string enemyTag;
    public float rotationSpeed = 0.5f;

    protected Unit target = null;
}