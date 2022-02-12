using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite slotSprite;
    public Sprite slotOnHoverSprite;

    private GameObject soldierOnSlot;
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
        //todo - différence click droit / gauche
        //       pour menu (upgrade / sell) ou build
        if(!CanPlaceSoldier())
        {
            //todo - overlay ? 
            return;
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
            soldierOnSlot = (GameObject)Instantiate(soldierToBuild, transform.position, transform.rotation);
            spriteRenderer.enabled = false;
        }

    }


    private bool CanPlaceSoldier()
    {
        return soldierOnSlot == null;
    }
}
