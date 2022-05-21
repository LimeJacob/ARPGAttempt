using UnityEngine;
using Unity;
using UnityEngine.U2D.Animation;

public abstract class Weapon : Equippable 
{
    [Range(0f, 5f)]
    [SerializeField] 
    protected float cooldownTime;
    public virtual void Attack() 
    {
        playerController.SetAttackCooldown(cooldownTime);
        playerController.SetState(PlayerState.Attacking);
    }
}
