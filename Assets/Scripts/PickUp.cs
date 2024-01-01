using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    [SerializeField] int scoreToIncrement;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Function to increment points
            PlayerManager playerManager = collision.gameObject.GetComponent<PlayerManager>();
            playerManager.IncrementScore(scoreToIncrement);
        }
    }
}
