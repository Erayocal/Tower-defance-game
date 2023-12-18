using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_death: MonoBehaviour
{
    Rigidbody2D rg;
    [SerializeField] private float enemy_health;
    [SerializeField] private float tower_damage;
    [SerializeField] private GameObject Enemy_gameObject;
    void Start()
    {
        rg= GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            enemy_health -= tower_damage;

            if (enemy_health == 0)
            {
                Destroy(Enemy_gameObject);

            }

        }

    }
    void Update()
    {
        
    }
    
    
}
