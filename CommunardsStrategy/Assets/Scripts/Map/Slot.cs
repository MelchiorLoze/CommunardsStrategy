using UnityEngine;

public class Slot : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite slotSprite;
    public Sprite slotOnHoverSprite;

    protected GameObject unitOnSlot;

    private int unitOnSlotPrice;

    #region OnMouseEvent
    
    //Sets different color to the slot by swapping sprite
    //when player hover with mouse
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
                spriteRenderer.enabled = true;                       //re render slot sprite
                BuildManager.instance.AddMoney(unitOnSlotPrice / 3); //when player sell one unit, give 1/3 of the original price back
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
                unitOnSlot = (GameObject)Instantiate(soldierToBuild, transform.position, transform.rotation);
                spriteRenderer.enabled = false;

                unitOnSlotPrice = BuildManager.instance.GetUnitToBuildCost();
            }
        }
    }
    #endregion


    protected bool IsSlotFree()
    {
        return unitOnSlot == null;
    }
}