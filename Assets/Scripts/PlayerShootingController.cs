using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    [SerializeField]
    private DamageProjectile playerProjectilePrefab;
    void Update()
    {
        bool Shoot = Input.GetKeyDown(KeyCode.Mouse0);
        if(Shoot)
        {
            DamageProjectile projectile = Instantiate(playerProjectilePrefab);
            projectile.transform.position = transform.position;
            projectile.InitProjectile(gameObject, transform.forward);
        }
    }
}
