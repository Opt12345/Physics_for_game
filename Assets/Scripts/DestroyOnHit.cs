using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    public GameObject destructionEffect; // เอฟเฟคที่จะแสดงเมื่อ game object ถูกทำลาย

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet") // ตรวจสอบว่ามีการชนกับ bullet
        {
            Destroy(gameObject); // ทำลาย game object ที่ถูกยิงโดน
            if (destructionEffect != null)
            {
                Instantiate(destructionEffect, transform.position, Quaternion.identity); // สร้างเอฟเฟคที่จะแสดง
            }
        }
    }
}
