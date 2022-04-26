using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHealth : MonoBehaviour
{
    [SerializeField] private int health;

    [SerializeField] private int maxHealth;

    private List<IHealthListener> listeners = new List<IHealthListener>();

    public void Start()
    {
        health = maxHealth;
    }

    public void Damage(int damage) 
    {
        health -= damage;
        foreach (IHealthListener listener in listeners) listener.NotifyDamaged();
        if (health <= 0) foreach (IHealthListener listener in listeners) listener.NotifyOutOfHealth(); 
    }

    public void Heal(int heal) 
    {
        health += heal;
        if (health > maxHealth) health = maxHealth;
        foreach (IHealthListener listener in listeners) listener.NotifyHealed();
    }

    public void Subscribe(IHealthListener listener) 
    {
        listeners.Add(listener);
    }

    public void UnSubscribe(IHealthListener listener) 
    {
        listeners.Remove(listener);
    }
}
