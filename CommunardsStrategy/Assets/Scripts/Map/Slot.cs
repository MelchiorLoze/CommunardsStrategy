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

    private void OnMouseDown()
    {
        
    }

    private bool CanPlaceSoldier()
    {
        return soldierOnSlot == null;
    }
}
