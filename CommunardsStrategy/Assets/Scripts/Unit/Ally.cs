using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Unit
{
    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();
    }

    protected void RotateTowardsTarget(Transform target)
    {
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    }

    // Update is called once per frame
    override public void Update()
    {
        base.Update();

        if (target == null)
            return;

        RotateTowardsTarget(target.transform);
    }

    public float rotationSpeed = 0.5f;
}
