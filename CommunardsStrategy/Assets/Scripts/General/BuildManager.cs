using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildManager : MonoBehaviour
{
    private GameObject soldierToBuild;

    public GameObject allySoldierPrefab;
    public GameObject allyCanonPrefab;
    public GameObject allyArtilleristPrefab;
    public GameObject allyBarrierPrefab;

    public GameObject[] HQList;

    public UnityEngine.UI.Image background;
    public Sprite[] backgrounds;

    public int money;
    public UnityEngine.UI.Text moneyText;

    public static BuildManager instance;

    public bool isBarrier = false;

    private int nextBackground = 0;
    private int unitToBeBuildCost = 0;

    public bool isInSellMode = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        soldierToBuild = null;
        money = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (HQList[HQList.Length - 1] == null)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SetSoldierToBuild(GameObject soldier, int cost, bool _isBarrier = false)
    {
        soldierToBuild = soldier;
        isBarrier = _isBarrier;
        unitToBeBuildCost = cost;
        isInSellMode = false;
    }

    public void buySoldier()
    {
        removeMoney(unitToBeBuildCost);
    }

    public void setSellMode()
    {
        isInSellMode = true;
        soldierToBuild = null;
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

    public int GetUnitToBuildCost()
    {
        return unitToBeBuildCost;
    }
    #endregion

}
