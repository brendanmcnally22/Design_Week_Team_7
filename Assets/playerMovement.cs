using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    public float dashCooldown = 2f;

    private float dashTimer = 0f;
    private float coolDownTimer = 0f;
    private bool isDashing = false;
    private Rigidbody2D rb;
    private Vector2 movement;

    public string horizontalInput, verticalInput;
    public KeyCode dashKey1 = KeyCode.LeftShift; // First dash key
    public KeyCode dashKey2 = KeyCode.RightShift; // Second dash key
    private playerCollision playerColl;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerColl = GetComponent<playerCollision>();
    }

    void Update()
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if (dashTimer > 0)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0)
            {
                isDashing = false;
            }
        }

        if (!isDashing)
        {
            movement.x = Input.GetAxisRaw(horizontalInput);
            movement.y = Input.GetAxisRaw(verticalInput);
            movement.Normalize();

            // Dash Input (Only if cooldown is over and player is NOT "It")
            if ((Input.GetKeyDown(dashKey1) || Input.GetKeyDown(dashKey2)) && coolDownTimer <= 0 && !playerColl.isIt)
            {
                Dash();
            }
        }
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.velocity = movement * speed;
        }
    }

    private void Dash()
    {
        isDashing = true;
        dashTimer = dashDuration;
        coolDownTimer = dashCooldown;
        rb.velocity = movement * dashSpeed;
    }
}
