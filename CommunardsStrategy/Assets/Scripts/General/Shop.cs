using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int soldierCost = 100;
    public int gunnerCost = 200;
    public int canonCost = 500;
    public int barrierCost = 300;

    private BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectBaseSoldier()
    {
        buildManager.SetUnitToBuild(buildManager.allySoldierPrefab, soldierCost);
    }

    public void SelectArtillerist()
    {
        buildManager.SetUnitToBuild(buildManager.allyGunnerPrefab, gunnerCost);
    }

    public void SelectCanon()
    {
        buildManager.SetUnitToBuild(buildManager.allyCanonPrefab, canonCost);
    }

    public void SelectBarrier()
    {
        buildManager.SetUnitToBuild(buildManager.allyBarrierPrefab,  barrierCost, true);
    }

    public void SellMode()
    {
        buildManager.SetSellMode();
    }
}