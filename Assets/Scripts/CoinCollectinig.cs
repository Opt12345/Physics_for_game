using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollectinig : MonoBehaviour
{
    private int coinCount = 0;
    public TextMeshProUGUI coinCountText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject); // ลบเหรียญที่ชนกับตัวละคร
            coinCount++; // เพิ่มจำนวนเหรียญ
            UpdateCoinCountUI(); // อัพเดท UI แสดงจำนวนเหรียญ
        }
    }

    void UpdateCoinCountUI()
    {
        coinCountText.text = "Coins: " + coinCount.ToString(); // แสดงจำนวนเหรียญที่ได้รับบน UI
    }
}
