using System.Collections.Generic;
using UnityEngine;

public class Equippable : MonoBehaviour
{
    [SerializeField] public List<StatModifier> Mods { get; }
    [SerializeField] public string Name { get; private set; }
    [SerializeField] private Sprite itemSprite;

    private int ID;

    public void OnChangeFrom() 
    {
        foreach (StatModifier modifier in Mods)
            modifier.Apply();
    }
    public void OnChangeTo() 
    {
        foreach (StatModifier modifier in Mods)
            modifier.Remove();
    }
}
