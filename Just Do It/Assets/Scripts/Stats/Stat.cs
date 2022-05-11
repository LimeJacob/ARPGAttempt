using UnityEngine;
using System;

[System.Serializable]
public class Stat
{
    [SerializeField] private float baseValue;
    [SerializeField] private float baseMultiplier = 1;

    public void AddMultiplier(float compound) 
    {
        baseMultiplier *= compound;
    }

    public float GetValue() 
    {
        return baseValue * baseMultiplier;
    }

    public void SetValue(float value) 
    { 
    
    }
}