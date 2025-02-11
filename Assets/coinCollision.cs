using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {

playerCollision playerColl = other.GetComponent<playerCollision>();

        //Check if the player is NOT "IT" 
        if (playerColl != null && !playerColl.isIt)
        {
            playerScore playerScore = other.GetComponent<playerScore>();

            if (playerScore != null)
            {
                playerScore.AddScore(1);
                Destroy(gameObject);

            }
        }
       
       
       
    }
}