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
        buildManager.SetSoldierToBuild(buildManager.allySoldierPrefab);
    }
    public void SelectCanon()
    {
        buildManager.SetSoldierToBuild(buildManager.allyCanonPrefab);
    }
    public void SelectArtillerist()
    {
        buildManager.SetSoldierToBuild(buildManager.allyArtilleristPrefab);
    }
    public void SelectBarrier()
    {
        buildManager.SetSoldierToBuild(buildManager.allyBarrierPrefab, true);
    }
}
