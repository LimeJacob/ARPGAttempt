using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] public HelmetSlot Helmet;
    //[SerializeField] public RingSlot Ring;
    //[SerializeField] public AmuletSlot Amulet;
    //[SerializeField] public BodySlot Body;
    //[SerializeField] public LeggingSlot Leggings;
    //[SerializeField] public BootSlot Boots;
    //[SerializeField] public WeaponSlot LHand;
    //[SerializeField] public WeaponSlot RHand;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeEquipment<T>(IEquipSlot<T> slot, T newItem) where T : Equippable
    {
        slot.GetItem().OnChangeFrom();
        slot.SetItem(newItem);
        newItem.OnChangeTo();
    }
}


public interface IEquipSlot<T> where T : Equippable
{
    public void SetItem(T t);
    public T GetItem();
}

public class Equippable : MonoBehaviour
{
    [SerializeField] public List<StatModifier> Mods { get; }
    [SerializeField] public string Name { get; private set; }
    [SerializeField] private Sprite itemSprite;
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

public abstract class Helmet : Equippable {}
public abstract class Armor : Equippable {}
public abstract class Leggings : Equippable {}
public abstract class Boots : Equippable {}
public abstract class Weapon : Equippable {}
public abstract class Ring : Equippable {}
public abstract class Amulet : Equippable {}

public class SpeedMultiplier 
{
    [SerializeField] private float value;
    public SpeedMultiplier(float v) 
    {
        value = v;
    }
}