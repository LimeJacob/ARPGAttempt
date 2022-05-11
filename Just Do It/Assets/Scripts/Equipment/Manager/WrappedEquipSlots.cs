using UnityEngine;

[System.Serializable]
public class EquipSlots 
{
    [SerializeField]
    private WeaponSlot weaponSlot;
    [SerializeField]
    private ShieldSlot shieldSlot;
    [SerializeField]
    private HelmetSlot helmetSlot;
    [SerializeField]
    private ArmorSlot armorSlot;
    [SerializeField]
    private LeggingSlot leggingSlot;
    public WeaponSlot Weapon { get => weaponSlot; }
    public ShieldSlot Shield { get => shieldSlot; }
    public HelmetSlot Helmet { get => helmetSlot; }
    public ArmorSlot Armor { get => armorSlot; }
    public LeggingSlot Leggings { get => leggingSlot; }
}