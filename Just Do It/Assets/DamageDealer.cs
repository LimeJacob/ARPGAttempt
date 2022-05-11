using UnityEngine;

public class DamageDealer : MonoBehaviour 
{
    [SerializeField] int damage;

    public virtual void DealDamage(Damageable damageable) 
    {
        damageable.TakeDamage(damage);
    }
}
