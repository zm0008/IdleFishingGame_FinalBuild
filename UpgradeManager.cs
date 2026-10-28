using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public FishInventory fishInventory;
    public PlayerHook hookStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnLinePressed()
    {
        if (fishInventory.balance >= 10)
        {
            fishInventory.balance -= 10;
            hookStats.LineLength += 5;
            Debug.Log("Line Upgraded");
        }
        else
        {
            Debug.Log("Not enough money to upgrade line");
        }
    }
    public void OnDamagePressed()
    {
        if (fishInventory.balance >= 10)
        {
            fishInventory.balance -= 10;
            hookStats.hookDamage += 5;
            Debug.Log("Line Upgraded");
        }
        else
        {
            Debug.Log("Not enough money to upgrade line");
        }

    }
}
