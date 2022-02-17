using UnityEngine;

public class BarrierSlot : Slot
{
    protected override void OnMouseDown()
    {
        if (IsSlotFree()) // checks if slot is available
        {
            if (BuildManager.instance.isBarrier) // checks if player wants to build a barrier
            {
                GameObject barrierToBuild = BuildManager.instance.GetUnitToBuild();
                if (barrierToBuild == null)
                {
                    //No soldier selected
                    return;
                }

                if (BuildManager.instance.IsBuildable())
                {
                    BuildManager.instance.BuySoldier(); 
                    unitOnSlot = (GameObject) Instantiate(barrierToBuild, transform.position, transform.rotation);
                    spriteRenderer.enabled = false; // disable sprite render to only show the unit and hide the slot
                }
            }
        }
    }
}