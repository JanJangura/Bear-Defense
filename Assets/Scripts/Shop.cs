using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public MoneyEditor moneyManager;

    public GameObject basicTowerPrefab;
    public int cost;

    public void PurchaseStandardBear()
    {
        Debug.Log("Standard Bear");
    }

    public void PurchasedSuperBear()
    {
        Debug.Log("Purchased Super Bear");
    }
}
