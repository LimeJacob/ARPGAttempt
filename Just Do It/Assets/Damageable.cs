using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] List<string> vulnerabilities = new List<string>();
    [SerializeField] int maxHealth;
    [SerializeField] int health;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage) 
    {
        health -= damage;
        if (health <= 0)
            Destroy(this);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (vulnerabilities.Contains(collision.gameObject.tag)) 
        {
            collision.gameObject.GetComponent<DamageDealer>().DealDamage(this);
        }
    }
}
