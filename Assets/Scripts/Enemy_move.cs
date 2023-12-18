using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move : MonoBehaviour
{
    Rigidbody2D rg;
    public float sp;
    float angle = 0;
    public float rs;
    private waypoints wp;
    private int wpIndex;
    void Start()
    {
        rg= GetComponent<Rigidbody2D>();
        wp= GameObject.FindGameObjectWithTag("Waypoints").GetComponent<waypoints>();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wp.waypoint[wpIndex].position, sp * Time.deltaTime);
        
        Vector3 targetDirection = wp.waypoint[wpIndex].position - transform.position;
        angle = Mathf.Atan2(targetDirection.x, targetDirection.y) * -Mathf.Rad2Deg;
        
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rs*Time.deltaTime);
        if (Vector2.Distance(transform.position, wp.waypoint[wpIndex].position) < 0.1f)
        {
            if (wpIndex < wp.waypoint.Length - 1)
            {
                wpIndex++;
            }
            else { Destroy(gameObject); }
        }
    }
}
