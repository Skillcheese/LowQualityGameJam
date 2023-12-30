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
    private GameObject Instigator;
    void Start()
    {
        FloatyMovement movement = GetComponent<FloatyMovement>();
        movement.SetVelocity(Random.insideUnitCircle * Speed);
    }

    public void SetInstigator(GameObject _Instigator)
    {

    }
}
