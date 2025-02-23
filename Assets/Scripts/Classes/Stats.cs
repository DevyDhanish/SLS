using System;
using UnityEngine;

[System.Serializable]
public class Stats
{
    public int Strength;
    public int Stamina;

    public void incStrength(int value){
        Strength += value;
    }

    public void incStamina(int value){
        Stamina += value;
    }
}
