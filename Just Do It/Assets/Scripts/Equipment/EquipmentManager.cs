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
        slots.Weapon.GetItem().OnEquip(player, sprlibraries.Weapon);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Weapon GetWeapon() => slots.Weapon.GetItem();
    public Armor GetArmor() => slots.Armor.GetItem();
    public Helmet GetHelmet() => slots.Helmet.GetItem();
    public Shield GetShield() => slots.Shield.GetItem();
    public Leggings GetLeggings() => slots.Leggings.GetItem();
    public EquipAnimators Animators { get => animators; }
}
