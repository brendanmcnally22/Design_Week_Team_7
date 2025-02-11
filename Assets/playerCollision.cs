using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public bool isIt = false; // is the player it?
    private SpriteRenderer spriteRenderer; // sprite renderer component
    private bool canTag = true; // can the player tag another player?;; need this for our cooldown.

    float cooldown = 2f; // cooldown for tagging another player
    float tagTimer = 0f; // timer for the cooldown

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>(); // get the sprite renderer component
        ChangeColor(); // change the color of the player
    }

    void Update()
    {
        TagCooldown();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {

        // Only wil tag if thks player is "It" and collides with another player
        if (isIt && collision.gameObject.CompareTag("Player"))
        {
            playerCollision otherPlayer = collision.gameObject.GetComponent<playerCollision>();

            if (otherPlayer != null && otherPlayer.canTag)
            {
                isIt = false;
                otherPlayer.isIt = true;

                
                ChangeColor();
                otherPlayer.ChangeColor();

                canTag = false;

                //StartCoroutine(TagCooldown());
            }
        }
    }
   private void TagCooldown()
    {

        if(tagTimer >= cooldown && canTag==false)
        {
            canTag = true;
            tagTimer = 0f;
        }
        else
        {
            tagTimer += Time.deltaTime;
        }

    }
    public void ChangeColor()
    {
       
       spriteRenderer.color = isIt ? Color.red : Color.green; // change the color of the player
        Debug.Log(gameObject.name + " changed color to " + spriteRenderer.color); // Debug message
    }
}
