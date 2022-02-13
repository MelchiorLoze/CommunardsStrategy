using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite slotSprite;
    public Sprite slotOnHoverSprite;

    private GameObject soldierOnSlot;
    private int soldierOnSlotPrice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if(soldierOnSlot == null)
            spriteRenderer.sprite = slotOnHoverSprite;
    }

    private void OnMouseExit()
    {
        if(soldierOnSlot == null)
            spriteRenderer.sprite = slotSprite;
    }

    private void OnMouseDown()
    {
        // forbids barrier from being put down on slots
        if (BuildManager.instance.isBarrier)
            return;

        if(!CanPlaceSoldier())
        {
            if (BuildManager.instance.isInSellMode)
            {
                //todo - overlay ?
                Destroy(soldierOnSlot);
                spriteRenderer.sprite = slotSprite;
                spriteRenderer.enabled = true;
                BuildManager.instance.addMoney(soldierOnSlotPrice / 3);
                return;
            }
        }
        else
        {
            GameObject soldierToBuild = BuildManager.instance.GetAllyToBuild();
            if(soldierToBuild == null)
            {
                //No soldier selected

                //todo - error message ? 
                print("no soldier selected");
                return;
            }
            if (BuildManager.instance.canBuild())
            {
                BuildManager.instance.buySoldier();
                soldierOnSlot = (GameObject)Instantiate(soldierToBuild, transform.position, transform.rotation);
                spriteRenderer.enabled = false;

                soldierOnSlotPrice = BuildManager.instance.GetUnitToBuildCost();
            }
        }

    }


    private bool CanPlaceSoldier()
    {
        return soldierOnSlot == null;
    }
}
