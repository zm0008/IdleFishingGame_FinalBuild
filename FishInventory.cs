using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishInventory : MonoBehaviour
{
    public Button SellButton;
    public List<float> inventory = new List<float>();
    public TMP_Text MoneyCounter;

    public float balance = 0f;

    public void FishCaught(float exampleVar1/*, float exampleVar2*/) //second variable removed, in final can calculate fish value in fish script then add value to inventory
    {
        Debug.Log("Added new fish to inventory");
        inventory.Add(exampleVar1/*, exampleVar2*/);
        Debug.Log("Inventory Values:" + string.Join(", ", inventory));
    }
    //Sell Button
    public void OnButtonPressed()
    {
        balance += inventory.Sum();
        Debug.Log(balance);
        inventory.Clear();
    }
    private void Update()
    {
        MoneyCounter.text = "$" + balance.ToString();
    }
}