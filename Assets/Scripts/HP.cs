using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public int maxRespawns = 3; // จำนวนครั้งที่สามารถ Respawn ได้
    private int respawnCount; // จำนวนครั้งที่เหลือ

    public TextMeshProUGUI respawnCountText; // Reference ไปยัง Text Element ที่แสดงจำนวนครั้งที่เหลือ

    void Start()
    {
        respawnCount = maxRespawns; // กำหนดค่าจำนวนครั้งที่เหลือให้เท่ากับค่าสูงสุดเมื่อเริ่มเกม
        UpdateRespawnCountUI(); // อัปเดต UI เพื่อแสดงจำนวนครั้งที่เหลือ
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // ตรวจสอบว่าเกิดการชนกับศัตรูหรือไม่
        {
            respawnCount--; // ลบจำนวนครั้งที่เหลือลง 1
            UpdateRespawnCountUI(); // อัปเดต UI เพื่อแสดงจำนวนครั้งที่เหลือ

            if (respawnCount>=1)return;
            else
            {
                if (respawnCount <= 0)
                {
                    Debug.Log("Game Over");
                    Respawn();
                }
            }
            
            
        }
    }

    void Respawn()
    {
        SceneManager.LoadScene("MapForPlay");
    }

    void UpdateRespawnCountUI()
    {
        respawnCountText.text = "x " + respawnCount.ToString(); // อัปเดต Text บน UI เพื่อแสดงจำนวนครั้งที่เหลือ
    }
}
