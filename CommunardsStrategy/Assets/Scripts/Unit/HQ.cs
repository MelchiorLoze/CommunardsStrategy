using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQ : Ally
{

    override public void Start()
    {
    }

    // Update is called once per frame
    override public void Update()
    {

    }
    protected override void Die()
    {
        BuildManager.instance.ChangeBackground();
        Destroy(gameObject);
    }
}
