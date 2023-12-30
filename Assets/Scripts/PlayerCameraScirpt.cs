using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraScirpt : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Transform CombatLookAt;
    public Rigidbody rb;
    public float rotationSpeed;
    private void Update()
    {
        player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(CombatLookAt.position - transform.position, Vector3.up), .6f);
    }
}
