using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatyMovement : MonoBehaviour
{
    protected Vector3 Velocity;
    protected Vector3 Acceleration;
    [SerializeField]
    protected float DampingAcceleration = .99f;
    [SerializeField]
    protected float DampingVelocity = .99f;

    public void SetAcceleration(Vector3 _Acceleration)
    {
        Acceleration = _Acceleration;
    }

    public void SetVelocity(Vector3 _Velocity)
    {
        Velocity = _Velocity;
    }

    // Update is called once per frame
    protected void Update()
    {
        Velocity += Acceleration * Time.deltaTime;
        transform.position += Velocity * Time.deltaTime;
        Velocity *= DampingVelocity;
        Acceleration *= DampingAcceleration;
    }
}
