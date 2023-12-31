using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField]
    private DamageProjectile BossProjectilePrefab;
    void Start()
    {
        StartCoroutine(BossScriptCoroutine());
    }

    private IEnumerator BossScriptCoroutine()
    {
        float shotDelay = .01f;
        int numProjectiles = 35;
        int numCircles = 14;
        StartCoroutine(DoShootingCircles(numProjectiles, numCircles, numProjectiles * shotDelay, shotDelay));
        yield break;
    }


    private IEnumerator DoShootingCircles(int _NumProjectiles, int _NumCircles, float _CircleDelay, float _ShotDelay)
    {
        float CircleAngleRight = 0;
        while (CircleAngleRight < 360)
        {
            StartCoroutine(DoShootingCircle(_NumProjectiles, 0, CircleAngleRight, _ShotDelay));
            CircleAngleRight += 360.0f / _NumCircles;
            yield return new WaitForSeconds(_CircleDelay);
        }
    }

    private IEnumerator DoShootingCircle(int _NumProjectiles, float _CircleAngleForward, float _CircleAngleRight, float _ShotDelay)
    {
        float CircleAngleUp = 0;
        Quaternion rotationBase = transform.rotation;
        rotationBase *= Quaternion.AngleAxis(_CircleAngleForward, Vector3.forward);
        rotationBase *= Quaternion.AngleAxis(_CircleAngleRight, Vector3.right);
        while(CircleAngleUp < 360)
        {
            DamageProjectile projectile = Instantiate(BossProjectilePrefab);
            projectile.transform.position = transform.position;
            Quaternion projectileRotation = rotationBase;
            projectileRotation *= Quaternion.AngleAxis(CircleAngleUp, Vector3.up);
            projectile.transform.rotation = projectileRotation;
            projectile.InitProjectile(gameObject, projectile.transform.forward);
            CircleAngleUp += 360.0f / _NumProjectiles;
            yield return new WaitForSeconds(_ShotDelay);
        }
    }
}
