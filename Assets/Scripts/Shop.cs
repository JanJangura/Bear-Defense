using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public MoneyEditor moneyManager;

    public GameObject standardbearPrefab;
    public GameObject superBearPrefab;

    private int StandardBearCost;
    private int SuperBearCost;

    [Header("Scriptable Object")]
    [SerializeField] private Bear standardBear;
    [SerializeField] private Bear superBear;

    private void Start()
    {
        StandardBearCost = standardBear.Cost;
        SuperBearCost = superBear.Cost;
    }

    public int GetTowerCost(GameObject towerPrefab)
    {
        int cost = 0;

        if (towerPrefab == standardbearPrefab)
        {
            cost = StandardBearCost;
        }
        else if(towerPrefab == superBearPrefab)
        {
            cost = SuperBearCost;
        }

        return cost;
    }

    public bool CanBuyTower(GameObject towerPrefab)
    {
        int cost = GetTowerCost(towerPrefab);

        bool canBuy = false;

        if(moneyManager.GetCurrentMoney() >= cost)
        {
            canBuy = true;
        }

        return canBuy;
    }

    public void BuyTower(GameObject towerPrefab)
    {
        moneyManager.RemoveMoney(GetTowerCost(towerPrefab));
    }
}
