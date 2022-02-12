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

    // Update is called once per frame
    override public void Update()
    {
        base.Update();

        if (target == null)
            return;

        RotateTowardsTarget(target.transform);
    }
}
