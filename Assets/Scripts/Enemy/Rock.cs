using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float raycastDistance = 1f;  // ระยะทางของ Raycast
    public float gravityOnPlayerPassed = 4f;  // ค่า Gravity เมื่อ Player ผ่าน Raycast
    public LayerMask playerLayer;  

    private Rigidbody2D rb;  // Rigidbody ของ Rock

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;  // เซ็ต Gravity ของ Rock เป็น 0 ตั้งแต่เริ่มเกม
    }

    void Update()
    {
        // สร้าง Raycast ในทิศทางลง (Vector3.down)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, raycastDistance, playerLayer);
        
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            Debug.Log("Fall!!");
            rb.gravityScale = gravityOnPlayerPassed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.collider.CompareTag("Player")) return;
        Destroy(gameObject,1.5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * raycastDistance);
    }
}
