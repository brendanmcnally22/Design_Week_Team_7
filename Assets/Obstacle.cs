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
                // player who is it please pass through please omgggg PLEASE 
                Physics2D.IgnoreCollision(other, GetComponent<Collider2D>());
            }
            else
            {
                // The player who IS "It" should pass through
                Debug.Log(other.gameObject.name + " is It and can pass through!");
            }
        }
    }
}
