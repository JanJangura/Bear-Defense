using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyEditor : MonoBehaviour
{
    [Header("Money!")]
    public int starterMoney = 250; // Starter Money

    private int currentPlayerMoney;

    public int GetCurrentMoney()
    {
        return currentPlayerMoney;
    }

    public void AddMonet(int amount)
    {
        currentPlayerMoney += amount;
    }

    public void RemoveMonet(int amount)
    {
        currentPlayerMoney -= amount;
    }
}
