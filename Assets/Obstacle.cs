using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        playerCollision playerColl = other.GetComponent<playerCollision>();

        if (playerColl != null)
        {
            if (!playerColl.isIt)
            {
                // the player who is not "IT" should be affected
                Debug.Log(other.gameObject.name + " hit an obstacle!");

                // send player back to spawn
                other.transform.position = new Vector2(0, 0); // Change to your respawn point
            }
            else
            {
                // The player who IS "It" should pass through
                Debug.Log(other.gameObject.name + " is It and can pass through!");
            }
        }
    }
}
