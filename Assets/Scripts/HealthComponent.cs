using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int Health { get; private set; }
    public int MaxHealth = 1;
    private void Start()
    {
        Health = MaxHealth;
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            Destroy(gameObject);
            //play particle effects
        }
    }
}
