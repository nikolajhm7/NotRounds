using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sprtrnd;
    [SerializeField] private Rigidbody2D rb2d;
    private Transform transf;
    private float idle = 0f;
    private float movementSpeed = 0f;
    private float maxSpeed = 6f;
    private float acceleration = 13f;
    private float deacceleration = -24f;
    private float maxAnimSpeed = 1f;
    private float animAcceleration = 2f;
    private float jumpHeight = 6f * 1.8f;
    private float dashMultiplier = 2;
    public static bool isGrounded;
    public static bool isOnPlatform;
    private bool isDashing;


    private void Start()
    {
        // anim.speed = 0 + 1;
        isDashing = false;
        transf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementSpeed < maxSpeed && Input.GetAxisRaw("Horizontal") > 0 && Time.timeScale != 0)
        {
            movementSpeed += acceleration * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
            sprtrnd.flipX = false;
            // if (anim.speed < maxAnimSpeed)
            // {
            // anim.speed += animAcceleration * Time.deltaTime;
            // }
        }

        if (movementSpeed > -maxSpeed && Input.GetAxisRaw("Horizontal") < 0 && Time.timeScale != 0)
        {
            movementSpeed += acceleration * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
            sprtrnd.flipX = true;
            // if (anim.speed < maxAnimSpeed)
            // {
            //     anim.speed += animAcceleration * Time.deltaTime;
            // }
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && movementSpeed > idle)
        {
            movementSpeed += deacceleration * Time.deltaTime;
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && movementSpeed < idle)
        {
            movementSpeed -= deacceleration * Time.deltaTime;
        }

        if (movementSpeed < 0.1 && movementSpeed > -0.1 && Input.GetAxisRaw("Horizontal") == 0 && Time.timeScale != 0)
        {
            movementSpeed = 0f;
            // anim.speed = 0 + 1;
        }

        if (Input.GetAxisRaw("Horizontal") > 0 && movementSpeed < 0 || Input.GetAxisRaw("Horizontal") < 0 && movementSpeed > 0)
        {
            movementSpeed *= 0.7f;
        }

        rb2d.velocity = new Vector2(movementSpeed, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale != 0 && isGrounded == true || Input.GetKeyDown(KeyCode.Space) && Time.timeScale != 0 && isOnPlatform == true)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {


            Debug.Log("faggot");
        }


        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") == true)
        {
            isGrounded = true; 
        }

        //if (collision.gameObject.CompareTag("Platform") == true)
        //{
        //    if (collision.gameObject.transform.position.y < transf.transform.position.y)
        //    {
        //    isOnPlatform = true;
        //    }
        //}
    }

    private void Jump()
    {
        rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpHeight), ForceMode2D.Impulse);
        isGrounded = false;
    }
}