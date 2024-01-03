using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraScirpt : MonoBehaviour
{
    public Transform player;
    public Transform CombatLookAt;
    private void Update()
    {
        if (CombatLookAt == null || player == null) return;
        player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(CombatLookAt.position - transform.position, Vector3.up), .6f);
    }
}
