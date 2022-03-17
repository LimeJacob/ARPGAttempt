using UnityEngine;
using System;

[System.Serializable]
public class Stat
{
    [SerializeField] private float baseValue;
    [SerializeField] public float baseMultiplier { get; set; }

    public float GetValue() 
    {
        return baseValue * baseMultiplier;
    }
}