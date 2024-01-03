using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    [SerializeField] int scoreToIncrement;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        if(other.gameObject.CompareTag("Player"))
        {
            //Function to increment points
            PlayerManager playerManager = other.gameObject.GetComponent<PlayerManager>();
            playerManager.IncrementScore(scoreToIncrement);
            Destroy(gameObject);
        }
    }
}
