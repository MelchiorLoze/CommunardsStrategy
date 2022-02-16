using UnityEngine;

public class BarrierSlot : Slot
{
    protected override void OnMouseDown()
    {
        if (IsSlotFree())
        {
            if (BuildManager.instance.isBarrier)
            {
                GameObject barrierToBuild = BuildManager.instance.GetUnitToBuild();
                if (barrierToBuild == null)
                {
                    //No soldier selected
                    print("no unit selected");
                    return;
                }

                if (BuildManager.instance.IsBuildable())
                {
                    BuildManager.instance.BuySoldier();
                    unitOnSlot = (GameObject) Instantiate(barrierToBuild, transform.position, transform.rotation);
                    spriteRenderer.enabled = false;
                }
            }
        }
    }
}