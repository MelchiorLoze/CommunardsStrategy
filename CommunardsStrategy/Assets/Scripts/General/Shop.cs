using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectBaseSoldier()
    {
        buildManager.SetSoldierToBuild(buildManager.allySoldierPrefab, (int) unitCost.SOLDIER);
    }
    public void SelectCanon()
    {
        buildManager.SetSoldierToBuild(buildManager.allyCanonPrefab, (int) unitCost.CANON);
    }
    public void SelectArtillerist()
    {
        buildManager.SetSoldierToBuild(buildManager.allyArtilleristPrefab, (int)unitCost.ARTILLERIST);
    }
    public void SelectBarrier()
    {
        buildManager.SetSoldierToBuild(buildManager.allyBarrierPrefab,  (int)unitCost.SOLDIER, true);
    }

    public void SellMode()
    {
        buildManager.setSellMode();
    }

    private enum unitCost
    {
        SOLDIER = 100,
        ARTILLERIST = 200,
        CANON = 300,
        BARRIER = 200
    }
}
