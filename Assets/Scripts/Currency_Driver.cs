﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency_Driver : MonoBehaviour
{
    private int playerMoney = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddMoney(int amount)
    {
        PlayerPrefsManager.money += amount;
        PlayerPrefsManager.UpdateCoins();
    }

    public void SubtractMoney(int amount)
    {
        if(PlayerPrefsManager.money < amount)
        {
            Debug.Log("Insufficient Funds");
       
        } else{
            PlayerPrefsManager.money -= amount;
            PlayerPrefsManager.UpdateCoins();
        }

        
    }

    public static int GetMoney()
    {
        return PlayerPrefsManager.money;
    }

}
