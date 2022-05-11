using UnityEngine;
using Unity;
using UnityEngine.U2D.Animation;


public abstract class Weapon : Equippable 
{
    [SerializeField]
    private SpriteLibraryAsset sprites;
    protected PlayerController playerController;
    [Range(0f, 5f)]
    [SerializeField] 
    protected float cooldownTime;
    public virtual void Attack() 
    {
        playerController.SetAttackCooldown(cooldownTime);
        playerController.SetState(PlayerState.Attacking);
    }

    // Called on equip
    public void OnEquip(PlayerController playerCont, SpriteLibrary wep) 
    { 
        playerController = playerCont;
        wep.spriteLibraryAsset = sprites;
    }
}
