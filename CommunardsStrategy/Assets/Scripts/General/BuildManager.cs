using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject allySoldierPrefab;
    public GameObject allyCanonPrefab;
    public GameObject allyGunnerPrefab;
    public GameObject allyBarrierPrefab;
    public GameObject[] HQList;

    public UnityEngine.UI.Image background;
    public Sprite[] backgrounds;

    public int money;
    public TextMeshProUGUI moneyText;
    public bool isInSellMode = false;
    public bool isBarrier = false;

    private int nextBackground = 0;
    private int unitToBuildCost = 0;
    private GameObject unitToBuildPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        unitToBuildPrefab = null;
        ChangeMoneyText();
    }

    // Update is called once per frame
    void Update()
    {
        // Launch game over when last HQ is destroyed
        if (HQList[HQList.Length - 1] == null)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Set which unit will be built on the slot
    //Disable SellMode
    public void SetUnitToBuild(GameObject unit, int cost, bool _isBarrier = false)
    {
        unitToBuildPrefab = unit;
        isBarrier = _isBarrier;
        unitToBuildCost = cost;
        isInSellMode = false;
    }

    //Remove money from bank depending on which soldier was built
    public void BuySoldier()
    {
        RemoveMoney(unitToBuildCost);
    }

    //Set sell mode
    //Set unit to be build to null, preventing player from building while in Sell mode
    public void SetSellMode()
    {
        isInSellMode = true;
        unitToBuildPrefab = null;
    }

    #region utility func
    public GameObject GetUnitToBuild()
    {
        return unitToBuildPrefab;
    }

    //Set next background
    //backgrounds are in the object as public var.
    public void ChangeBackground()
    {
        background.overrideSprite = backgrounds[nextBackground];
        nextBackground++;
    }

    private void ChangeMoneyText()
    {
        moneyText.text = money.ToString();
    }

    public void AddMoney(int amount)
    {
        money += amount;

        ChangeMoneyText();
    }

    private void RemoveMoney(int amount)
    {
        if (amount > money)
        {
            return;
        }
        money -= amount;
        ChangeMoneyText();
    }

    //Check if player has enough money to build the specified unit
    public bool IsBuildable()
    {
        return money - unitToBuildCost >= 0;
    }

    public int GetUnitToBuildCost()
    {
        return unitToBuildCost;
    }
    #endregion
}