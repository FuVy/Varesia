using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    float horizontalMovement;
    [SerializeField] float jumpForce = 5f;
    [Header("ground")]
    private readonly float checkRadius = 0.2f;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] Transform groundCheck;

    [SerializeField] Rigidbody2D secondObject;
    bool isGrounded = true;
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal2");
        HandleJumping();
    }

    private void HandleJumping()
    {
        if (Input.GetAxisRaw("Vertical2") == 1f && isGrounded)
        {
            rigidbody.velocity = Vector2.up * jumpForce + new Vector2(rigidbody.velocity.x, 0);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.velocity += new Vector2(horizontalMovement, 0);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //rigidbody.drag = 5 * Convert.ToInt32(isGrounded);
        HandleSwinging();
    }

    void HandleSwinging()
    {
        if (!isGrounded)
        {
            rigidbody.drag = 4f;
            secondObject.mass = 2f;
        }
        else
            secondObject.mass = 1f;
    }

    public void HandleDeath()
    {
        FindObjectOfType<CameraMovement>().enabled = false;
        FindObjectOfType<Square>()?.HandleTriangleDeath();   //костыль
        Destroy(this.gameObject);
        FindObjectOfType<Line>().HandleDeath();
        //какие-то эффекты запульнуть
        FindObjectOfType<Fade>().HandleDeath();
    }

    public void HandleSquareDeath()
    {
        secondObject = GetComponent<Rigidbody2D>();
    }
}
