using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : Ally
{
    // Start is called before the first frame update
    override public void Start()
    {
    }

    // Update is called once per frame
    override public void Update()
    {
        
    }

    public void Reorientation(Transform target)
    {
        RotateTowardsTarget(target);
    }
}
