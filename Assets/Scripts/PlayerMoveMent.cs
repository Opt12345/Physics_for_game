using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jupmForce;
    private Rigidbody2D rb;
    private bool isGround;
    
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }  // Start is called before the first frame update
    
    void Update()
    {
        // move
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0f) * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        
        // Check Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jupmForce);
            isGround = false;
        }
        
    } // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        
    } // Check Ground
}
