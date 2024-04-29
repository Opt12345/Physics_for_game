using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject target;
    public Rigidbody2D bullet;
    
    void Update()
    {
        Debug.Log(Camera.main);
        Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (ray - (Vector2)transform.position).normalized;
        Debug.DrawRay((Vector2)transform.position , direction * 5 , Color.red);
        
        
        
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }

    /*Vector2 CalculateProjectile(Vector2 origin , Vector2 target)
    {
        
    }*/
}
