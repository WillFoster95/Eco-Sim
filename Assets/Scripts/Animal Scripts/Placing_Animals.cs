﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placing_Animals : MonoBehaviour
{


    public void BearButton()
    {
        Debug.Log("Button pressed");       
        Animal_Manager.NewAnimal("Bear", new Vector3(0, 0, 1));

        Placement_Script ps = new Placement_Script();

       
    } 

    public void HareButton()
    {
        Debug.Log("Button pressed");
        Animal_Manager.NewAnimal("Hare", new Vector3(0, 0, 1));
    }

    public void MooseButton()
    {
        Animal_Manager.NewAnimal("Moose", new Vector3(0, 0, 1));
    }

    public void WolfButton()
    {
        Animal_Manager.NewAnimal("Wolf", new Vector3(0, 0, 1));
    }
}