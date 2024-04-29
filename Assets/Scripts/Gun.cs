using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject target;
    public Rigidbody2D bullet;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Camera.main);                                                              
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.transform.position = mousePos;
            Vector2 direction = (mousePos - (Vector2)transform.position).normalized;             
            Debug.DrawRay((Vector2)transform.position , direction * 5 , Color.red);              
                                                                                      
            target.transform.position = mousePos;

            Vector2 projectileV = CalculateProjectile(shootPoint.position , mousePos , 1 );
            Rigidbody2D spawnBullet = Instantiate(bullet , shootPoint.position , Quaternion.identity );
            spawnBullet.velocity = projectileV;
        }
    }

    Vector2 CalculateProjectile(Vector2 origin, Vector2 targetPoint , float time)
    {
        Vector2 distance = targetPoint - origin;
        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        Vector2 projecttileVelocity = new Vector2(velocityX, velocityY);
        return projecttileVelocity;

    }
}
