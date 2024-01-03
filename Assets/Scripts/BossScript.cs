using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField]
    private DamageProjectile BossProjectilePrefab;
    [SerializeField]
    private DamageProjectile BossProjectileMachineGunPrefab;
    private GameObject player { get { return GameObject.Find("Player"); } }
    void Start()
    {
        StartCoroutine(BossScriptCoroutine());
    }

    private IEnumerator BossScriptCoroutine()
    {
        float shotDelay;
        int numProjectiles;
        int numCircles = 18;
        float attackDelay;
        float downtime = 0;
        yield return new WaitForSeconds(5);
        while(true)
        {
            float rand = Random.Range(0, 1.0f);
            shotDelay = .01f;
            numProjectiles = 35;
            float circleDelay = numProjectiles * shotDelay;
            StartCoroutine(DoShootingCircles(numProjectiles, numCircles, circleDelay, shotDelay));
            attackDelay = circleDelay * numCircles;
            if(rand < .5f)
            {
                numProjectiles = 20;
                shotDelay = attackDelay / numProjectiles;
                StartCoroutine(DoMachineGun(numProjectiles, shotDelay));
            }
            else
            {
                numProjectiles = 10;
                StartCoroutine(DoCross(numProjectiles, attackDelay / numProjectiles));
            }
            yield return new WaitForSeconds(attackDelay + downtime);
        }
    }

    private IEnumerator DoCross(int _Size, float _ShotDelay)
    {
        int currentSize = 0;
        while(currentSize < _Size)
        {
            for(int horizontalVertical = -1; horizontalVertical <= 0; horizontalVertical++)
            {
                for(int x = -currentSize; x <= currentSize; x++)
                {
                    DamageProjectile projectile = Instantiate(BossProjectileMachineGunPrefab);
                    projectile.transform.position = transform.position;
                    if (player == null) yield break;
                    projectile.transform.rotation = Quaternion.LookRotation(player.transform.position - projectile.transform.position, Vector3.up);
                    Vector3 diff = projectile.transform.up;
                    if(horizontalVertical == 0)
                    {
                        diff = projectile.transform.right;
                    }
                    projectile.transform.position += diff * x;
                    projectile.InitProjectile(gameObject, projectile.transform.forward);
                }
            }
            currentSize++;
            yield return new WaitForSeconds(_ShotDelay);
        }
    }
    
    private IEnumerator DoMachineGun(int _NumProjectiles, float _ShotDelay)
    {
        while(_NumProjectiles > 0)
        {
            _NumProjectiles--;
            DamageProjectile projectile = Instantiate(BossProjectileMachineGunPrefab);
            projectile.transform.position = transform.position;
            if (player == null) yield break;
            projectile.transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up);
            projectile.InitProjectile(gameObject, projectile.transform.forward);
            yield return new WaitForSeconds(_ShotDelay);
        }
    }


    private IEnumerator DoShootingCircles(int _NumProjectiles, int _NumCircles, float _CircleDelay, float _ShotDelay)
    {
        float CircleAngleRight = 0;
        while (CircleAngleRight < 180)
        {
            StartCoroutine(DoShootingCircle(_NumProjectiles, 0, CircleAngleRight, _ShotDelay));
            CircleAngleRight += 180 / _NumCircles;
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
