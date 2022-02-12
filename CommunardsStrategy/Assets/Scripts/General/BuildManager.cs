using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject soldierToBuild;

    public GameObject allySoldierPrefab;
    public GameObject allyCanonPrefab;
    public GameObject allyArtilleristPrefab;
    public GameObject allyBarrierPrefab;

    public static BuildManager instance;

    public bool isBarrier = false;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        soldierToBuild = null;
    }

    public GameObject GetAllyToBuild()
    {
        return soldierToBuild;
    }

    public void SetSoldierToBuild(GameObject soldier, bool _isBarrier = false)
    {
        soldierToBuild = soldier;
        isBarrier = _isBarrier;
    }

    public void ApplyShopUI(Slot slot)
    {
        //preparing a function
        //to teleport shop UI 
        //to a specific slot
    }
}
