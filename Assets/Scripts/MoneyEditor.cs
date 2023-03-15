using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyEditor : MonoBehaviour
{
    [Header("Money!")]
    public int starterMoney; // Starter Money
    public TextMeshProUGUI currentMoney;   

    private int currentPlayerMoney;

    public void Start()
    {
        currentPlayerMoney = starterMoney;
    }

    private void Update()
    {
        currentMoney.text = "$ " + currentPlayerMoney.ToString();       
    }

    public int GetCurrentMoney()
    {
        return currentPlayerMoney;
    }

    public void AddMoney(int amount)
    {
        currentPlayerMoney += amount;
    }

    public void RemoveMoney(int amount)
    {
        currentPlayerMoney -= amount;       
    }
}
