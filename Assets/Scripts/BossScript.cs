using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField]
    private DamageProjectile BossProjectilePrefab;
    void Start()
    {
        StartCoroutine(DoShootingCircle(8, 0, 0));
    }

    private IEnumerator DoShootingCircle(int _NumProjectiles, float _CircleAngleForward, float _CircleAngleRight)
    {
        float CircleAngleUp = 0;
        Quaternion rotationBase = transform.rotation;
        rotationBase *= Quaternion.AngleAxis(_CircleAngleForward, Vector3.forward);
        rotationBase *= Quaternion.AngleAxis(_CircleAngleRight, Vector3.right);
        while(CircleAngleUp <= Mathf.PI * 2)
        {
            DamageProjectile projectile = Instantiate(BossProjectilePrefab);
            projectile.transform.position = transform.position;
            Quaternion projectileRotation = rotationBase;
            projectileRotation *= Quaternion.AngleAxis(CircleAngleUp, Vector3.up);
            projectile.transform.rotation = projectileRotation;
            projectile.InitProjectile(gameObject, projectile.transform.forward);
            CircleAngleUp += Mathf.PI * 2 / _NumProjectiles;
            yield return new WaitForSeconds(1);
        }
    }
}
