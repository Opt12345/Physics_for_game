using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // กำหนดให้เป็นตำแหน่งของ Player หรือ Object ที่ต้องการให้กล้องติดตาม
    [SerializeField] private float smoothSpeed = 0.125f; // ความเร็วในการติดตาม
    [SerializeField] private Vector3 offset; // ระยะห่างระหว่างกล้องกับ Object

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // หาตำแหน่งที่ต้องการให้กล้องอยู่

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // สร้างเครื่องหมายลืมเพื่อทำให้กล้องเคลื่อนที่อย่างนุ่มนวล

        transform.position = smoothedPosition; // ตั้งค่าตำแหน่งของกล้อง
    }
}
