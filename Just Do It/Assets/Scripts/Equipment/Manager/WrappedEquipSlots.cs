using UnityEngine;

[System.Serializable]
public class EquipSlots 
{
    [SerializeField]
    private WeaponSlot weapon;
    [SerializeField]
    private ShieldSlot shield;
    [SerializeField]
    private HelmetSlot helmet;
    [SerializeField]
    private ArmorSlot armor;
    [SerializeField]
    private LeggingSlot leggings;
    public WeaponSlot Weapon { get => weapon; set { weapon = value; } }
    public ShieldSlot Shield { get => shield; set { shield = value; } }
    public HelmetSlot Helmet { get => helmet; set { helmet = value; } }
    public ArmorSlot Armor { get => armor; set { armor = value; } }
    public LeggingSlot Leggings { get => leggings; set { leggings = value; } }
}