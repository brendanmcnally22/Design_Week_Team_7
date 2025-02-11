using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed = 5f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    public float dashCooldown = 2f;

    private bool canDash = true;
    private bool isDashing = false;
    private Rigidbody2D rb;
    private Vector2 movement;

    public string horizontalInput, verticalInput; // input strings
    private playerCollision playerColl;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerColl = GetComponent<playerCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDashing)
        {
            movement.x = Input.GetAxisRaw(horizontalInput); // get the horizontal input
            movement.y = Input.GetAxisRaw(verticalInput); // get the vertical input
            movement.Normalize(); // prevent diagonal movement from being faster
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash&& !playerColl.isIt)
        {
            Debug.Log(gameObject.name + "started dashing"); 
            StartCoroutine(Dash());
        }

    }

     void FixedUpdate()
    {
        rb.velocity = movement * speed; // move the player
    }

    private IEnumerator Dash()
    {
        Debug.Log(gameObject.name + "dashing");
        canDash = false;
        isDashing = true; 
        rb.velocity = movement * dashSpeed; // move the player


        yield return new WaitForSeconds(dashDuration); // wait for the dash duration


        isDashing = false;
        rb.velocity = movement * speed; // reset to normal speed
        

        Debug.Log(gameObject.name + "stopped dashing waiting for cooldown");
        yield return new WaitForSeconds(dashDuration);


        Debug.Log(gameObject.name + "cooldown finished");
        canDash = true;

    }
}
