using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMoveMent : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float jupmForce;
    [SerializeField] private float maxStamina;
    
    [SerializeField] private float regenStamina;
    [SerializeField] private float staminaDrain;
    
    public Slider staminaSlider;

    private float currentSpeed;
    [SerializeField] private float currentStamina;
    private Rigidbody2D rb;
    private bool isGround = true;
    private bool isJumping = false;
    private bool isSprinting;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentStamina = maxStamina;
        currentSpeed = moveSpeed;
        UpdateStaminaUI();

    }  // Start is called before the first frame update
    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
            
        }
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Sprint(); 
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jupmForce);
            isJumping = false;
        }

        RegenerateStamina();
        UpdateStaminaUI();
    }
    
    private void FixedUpdate()
    {
        RegenerateStamina();
    }

    private void Jump()
    {
        if (currentStamina > 0 && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jupmForce);
            currentStamina -= 10f; // Adjust this value as needed
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina) * Time.deltaTime;
            UpdateStaminaUI();
            isJumping = true;
            isGround = false;
        }
    }

    private void Sprint()
    {
        rb.velocity = new Vector2(sprintSpeed,rb.velocity.x);
        currentStamina -= staminaDrain * Time.deltaTime;
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        UpdateStaminaUI();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    private void UpdateStaminaUI()
    {
        staminaSlider.value = currentStamina / maxStamina;
    }
    private void RegenerateStamina()
    {
        if (!isSprinting && currentStamina < maxStamina && !Input.GetKey(KeyCode.LeftShift))
        {
            currentStamina += regenStamina * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
            UpdateStaminaUI();
        }
    }
}
