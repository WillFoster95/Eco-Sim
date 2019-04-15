﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;

public class Hare_Script : MonoBehaviour
{
    Hare h = new Hare();
    GameObjectGUID guid;
    System.Random rnd = new System.Random();
    private static System.Timers.Timer hareTimer;
    Hare_Nest_Script closestNest;
    bool hasNest;

    public void Start()
    {
        SetTimer();
        hasNest = false;
        guid = GetComponent<GameObjectGUID>();
        guid.gameObjectID = rnd.Next();
    }

    public void Update()
    {
        if(hasNest == false)
        {
            findClosestNest();
            hasNest = closestNest.addHareToNest(this.gameObject);
        }  
    }

    private void FixedUpdate()
    {
        h.hungerLevel -= h.hungerDecayRate;
        h.tirednessLevel -= h.tirednessDecayRate;
        h.thirstLevel -= h.thirstDecayRate;
    }

    private void SetTimer()
    {
        hareTimer = new System.Timers.Timer(60000);
        hareTimer.Elapsed += OnTimedEvent;
        hareTimer.AutoReset = true;
        hareTimer.Enabled = true;
    }

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        Currency_Driver.AddMoney(h.currencyGain);
    }

    public void findClosestNest()
    {
        float distanceToClosestNest = Mathf.Infinity;
        closestNest = null;
        Hare_Nest_Script[] allNests = GameObject.FindObjectsOfType<Hare_Nest_Script>();

        foreach(Hare_Nest_Script currentNest in allNests){
            float distanceToNest = (currentNest.transform.position - this.transform.position).sqrMagnitude;

            if(distanceToNest < distanceToClosestNest)
            {
                distanceToClosestNest = distanceToNest;
                closestNest = currentNest;
                Debug.Log("Distance to closest nest found");
            }

        }

        Debug.DrawLine(this.transform.position, closestNest.transform.position);
    }

    void OnMouseDown()
    {
        Info_Panel.OpenBox(h.hungerLevel, h.tirednessLevel, h.thirstLevel, h.animalName, h.animalAge, h.animalSex, guid.gameObjectID);
    }
   
    public float GetHungerLevel()
    {
        return h.hungerLevel;
    }
    public float GetTirednessLevel()
    {
        return h.tirednessLevel;
    }
    public float GetThirstLevel()
    {
        return h.thirstLevel;
    }
    
}
