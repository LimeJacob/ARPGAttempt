using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slasher : Weapon
{
    public Transform player;
    public Vector2 position;
    [SerializeField] private GameObject slash;
    public override void Attack() 
    {
        Instantiate(slash, player);
    }
}