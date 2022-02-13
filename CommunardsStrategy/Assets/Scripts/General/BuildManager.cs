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

    public UnityEngine.UI.Image background;
    public Sprite[] backgrounds;

    public int money;
    public UnityEngine.UI.Text moneyText;

    public static BuildManager instance;

    public bool isBarrier = false;

    private int nextBackground = 0;
    private int unitToBeBuildCost = 0;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        soldierToBuild = null;
        money = 1000;
    }

    public void SetSoldierToBuild(GameObject soldier, int cost, bool _isBarrier = false)
    {
        soldierToBuild = soldier;
        isBarrier = _isBarrier;
        unitToBeBuildCost = cost;
    }

    public void buySoldier()
    {
        removeMoney(unitToBeBuildCost);
    }

    #region utility func
    public GameObject GetAllyToBuild()
    {
        return soldierToBuild;
    }
    public void ChangeBackground()
    {
        background.overrideSprite = backgrounds[nextBackground];
        nextBackground++;
    }
    private void changeMoneyText()
    {
        moneyText.text = money + " 𝑓";
    }
    public void addMoney(int amount)
    {
        money += amount;

        changeMoneyText();
    }

    private void removeMoney(int amount)
    {
        if (amount > money)
        {
            return;
        }
        money -= amount;
        changeMoneyText();
    }

    public bool canBuild()
    {
        return money - unitToBeBuildCost > 0;
    }
    #endregion

}
