using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamScript : MonoBehaviour
{
    [SerializeField]
    private int Damage = 1;
    private GameObject Instigator;
    private float RotationDuration = 5;
    private float time;
    public void InitLaserBeam(GameObject _Instigator, float _RotationDuration, float startingAngle)
    {
        Instigator = _Instigator;
        RotationDuration = _RotationDuration;
        GetComponent<Collider>().enabled = true;
        time = startingAngle / RotationDuration / 360;
    }

    private void Update()
    {
        time += Time.deltaTime;
        float alpha = 360 * time / RotationDuration;
        transform.parent.rotation = Quaternion.Euler(0, alpha, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Instigator) return;
        HealthComponent hp = other.GetComponent<HealthComponent>();
        if (!hp) return;
        hp.TakeDamage(Damage);
    }
}
