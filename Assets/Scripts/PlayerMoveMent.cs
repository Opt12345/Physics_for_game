using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMoveMent : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce; 
    private Rigidbody2D rb;
    private bool grounded;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }  
    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * walkSpeed, rb.velocity.y);
        
        // Flip
        if (moveHorizontal > 0.01f)
            transform.localScale = Vector3.one;
        else if (moveHorizontal < -0.001f)
            transform.localScale = new Vector3(-1, 1, 1);
        
        //Jump
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
