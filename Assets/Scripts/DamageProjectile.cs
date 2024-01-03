using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FloatyMovement))]
public class DamageProjectile : MonoBehaviour
{
    [SerializeField]
    public int Damage = 1;
    [SerializeField]
    public float Speed = 1;
    [SerializeField]
    public float Lifetime = 10;
    private GameObject Instigator;

    public void InitProjectile(GameObject _Instigator, Vector3 _Velocity)
    {
        Instigator = _Instigator;
        FloatyMovement movement = GetComponent<FloatyMovement>();
        movement.SetVelocity(_Velocity * Speed);
        GetComponent<Collider>().enabled = true;
        Destroy(gameObject, Lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Instigator) return;
        if (other.GetComponent<DamageProjectile>()) return;
        HealthComponent hp = other.GetComponent<HealthComponent>();
        hp.TakeDamage(Damage);
        Destroy(this);
        Destroy(gameObject);
    }
}
