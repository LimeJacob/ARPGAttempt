using System.Collections;
using UnityEngine;
public class EquipmentManager : MonoBehaviour
{
    [SerializeField]
    PlayerController player;
    [SerializeField]
    EquipAnimators animators;
    [SerializeField]
    EquipSlots slots;
    [SerializeField]
    EquipLibraries sprlibraries;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCharacter").GetComponent<PlayerController>();

        animators.Shield = GameObject.Find("ShieldAnimator").GetComponent<Animator>();
        animators.Weapon = GameObject.Find("WeaponAnimator").GetComponent<Animator>();

        slots.Leggings = GetComponentInChildren<LeggingSlot>();
        slots.Armor = GetComponentInChildren<ArmorSlot>();
        slots.Helmet = GetComponentInChildren<HelmetSlot>();
        slots.Weapon = GetComponentInChildren<WeaponSlot>();
        slots.Shield = GetComponentInChildren<ShieldSlot>();

        slots.Weapon.GetItem().OnEquip(player, sprlibraries.Weapon);
    }

    public Weapon GetWeapon() => slots.Weapon.GetItem();
    public Armor GetArmor() => slots.Armor.GetItem();
    public Helmet GetHelmet() => slots.Helmet.GetItem();
    public Shield GetShield() => slots.Shield.GetItem();
    public Leggings GetLeggings() => slots.Leggings.GetItem();
    public EquipAnimators Animators { get => animators; }
}
