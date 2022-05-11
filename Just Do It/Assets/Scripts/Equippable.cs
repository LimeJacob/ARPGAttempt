using System.Collections.Generic;
using UnityEngine;

public class Equippable : MonoBehaviour
{
    [SerializeField] public string Name { get; private set; }
    [SerializeField] private Sprite itemSprite;

    private int ID;

    public void OnChangeFrom() 
    {
        // Apply New Stats
    }
    public void OnChangeTo() 
    {
        // Remove Old Stats

        //Suggested: Create class that can have apply and remove called on it for each attribute.
    }
}
