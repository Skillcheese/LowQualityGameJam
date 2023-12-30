using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int Health { get; private set; }
    [SerializeField]
    public int MaxHealth { get; private set; }
    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
