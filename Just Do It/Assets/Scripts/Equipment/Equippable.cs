using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public abstract class Equippable : MonoBehaviour
{
    [SerializeField]
    private SpriteLibraryAsset sprites;
    protected PlayerController playerController;

    [SerializeField] private GameObject EquipEffectList;
    [SerializeField] public List<OnEquip> EquipEffect;
    [SerializeField] public string Name { get; private set; }
    [SerializeField] private Sprite itemSprite;

    public void Start()
    {
        EquipEffect = new List<OnEquip>(EquipEffectList.GetComponents<OnEquip>());
    }

    // Called on equip
    public void OnEquip(PlayerController playerCont, SpriteLibrary wep)
    {
        playerController = playerCont;
        wep.spriteLibraryAsset = sprites;
        foreach (OnEquip effect in EquipEffect)
            effect.Apply(playerController);
        
    }
    
    public void OnUnequip()
    {
        foreach (OnEquip effect in EquipEffect)
            effect.Remove(playerController);
    }
}
