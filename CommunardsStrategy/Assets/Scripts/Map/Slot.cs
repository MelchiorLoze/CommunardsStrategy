using UnityEngine;

public class Slot : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite slotSprite;
    public Sprite slotOnHoverSprite;

    protected GameObject unitOnSlot;

    private int unitOnSlotPrice;

    private void OnMouseOver()
    {
        if (IsSlotFree())
            spriteRenderer.sprite = slotOnHoverSprite;
    }

    private void OnMouseExit()
    {
        if (IsSlotFree())
            spriteRenderer.sprite = slotSprite;
    }

    protected virtual void OnMouseDown()
    {
        // forbids barrier from being put down on slots
        if (BuildManager.instance.isBarrier)
            return;

        if (!IsSlotFree())
        {
            if (BuildManager.instance.isInSellMode)
            {
                Destroy(unitOnSlot);
                spriteRenderer.sprite = slotSprite;
                spriteRenderer.enabled = true;
                BuildManager.instance.AddMoney(unitOnSlotPrice / 3);
                return;
            }
        }
        else
        {
            GameObject soldierToBuild = BuildManager.instance.GetUnitToBuild();
            if (soldierToBuild == null)
            {
                //No soldier selected
                return;
            }
            if (BuildManager.instance.IsBuildable())
            {
                BuildManager.instance.BuySoldier();
                unitOnSlot = (GameObject) Instantiate(soldierToBuild, transform.position, transform.rotation);
                spriteRenderer.enabled = false;

                unitOnSlotPrice = BuildManager.instance.GetUnitToBuildCost();
            }
        }
    }

    protected bool IsSlotFree()
    {
        return unitOnSlot == null;
    }
}