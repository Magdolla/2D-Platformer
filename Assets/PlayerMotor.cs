using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    public float dashForce = 10;
    public float dashTime = 0.5f;   
    private bool canJump = true;
    private Rigidbody2D rigidbody2D;
    public float speed = 10;
    public float maxSpeed = 10;
    public float jumpForce = 10;
    public float stoppingForce = 5;

    private int jumpCount = 0;
    private int maxJumpCount = 2;

    private bool isDashing = false;

  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        PlayerMovement();
        HandleMaxSpeed();
        PlayerStopping();

    }

    private void PlayerMovement()
    {
        rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));
    }

    private void HandleMaxSpeed()
    {
        
        NewMethod();

    }

    private void NewMethod()
    {
        if (rigidbody2D.linearVelocityX >= maxSpeed)
        {
            rigidbody2D.linearVelocityX = maxSpeed;
        }

        else if (rigidbody2D.linearVelocityX <= -maxSpeed)
        {
            rigidbody2D.linearVelocityX = -maxSpeed;
        }
    }

    private void PlayerStopping()
    {
        if (direction.x == 0 && rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingForce, 0));
        }
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
    private void OnJump()
    {
        if (canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
            if (jumpCount >= maxJumpCount)
            {
                canJump = false;
            }
        }
    }

    private void OnDash()
    {
       if(isDashing)
        {
            return;
        }
        isDashing = true;
        rigidbody2D.AddForce(new Vector2(direction.x * dashForce ,0), ForceMode2D.Impulse);
        StartCoroutine(ResetDash(dashTime));
    }

    IEnumerator ResetDash(float TimeToRest)
    {
        yield return new WaitForSeconds(TimeToRest);
        isDashing = false;
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        jumpCount = 0;
    }

    

}
