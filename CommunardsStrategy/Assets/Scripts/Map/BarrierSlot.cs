using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSlot : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite slotSprite;
    public Sprite slotOnHoverSprite;

    public GameObject waypointOrientation;

    private GameObject barrierOnSlot;

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
        if (barrierOnSlot == null)
            spriteRenderer.sprite = slotOnHoverSprite;
    }

    private void OnMouseExit()
    {
        if (barrierOnSlot == null)
            spriteRenderer.sprite = slotSprite;
    }


    private void OnMouseDown()
    {
        //todo - différence click droit / gauche
        //       pour menu (upgrade / sell) ou build
        if (!CanPlaceBarrier())
        {
            //todo - overlay ? 
            return;
        }
        else
        {
            if (BuildManager.instance.isBarrier)
            {
                GameObject barrierToBuild = BuildManager.instance.GetAllyToBuild();
                if (barrierToBuild == null)
                {
                    //No soldier selected

                    //todo - error message ? 
                    print("no unit selected");
                    return;
                }

                if (BuildManager.instance.canBuild())
                {
                    BuildManager.instance.buySoldier();
                    barrierOnSlot = (GameObject)Instantiate(barrierToBuild, transform.position, transform.rotation);
                    barrierOnSlot.GetComponent<Barrier>().Reorientation(waypointOrientation.transform);
                    spriteRenderer.enabled = false;
                }
            }
        }
    }

    private bool CanPlaceBarrier()
    {
        return barrierOnSlot == null;
    }
}
