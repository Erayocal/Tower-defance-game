using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
public class Tower_shoot : MonoBehaviour
{
    //[SerializeField] private float enemy_health;
    //[SerializeField] private float tower_damage;
    //[SerializeField] private GameObject Enemy;
    private Transform target;
    private Rigidbody2D rb;
    public float force;
    //GameObject Enemydt;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        //Enemydt = Enemy;
        Vector3 dir=target.transform.position-transform.position;
        rb.velocity = new Vector2(dir.x,dir.y).normalized*force;
        float rot = Mathf.Atan2(-dir.y,-dir.x)*Mathf.Rad2Deg;
        transform.rotation=Quaternion.Euler(0,0,rot+90);
    }
    public void SetTarget(Transform _target) { target= _target; }
    void FixedUpdate()
    {
        if(!target) return;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
     {
         if (collision.gameObject.CompareTag("Enemy"))
         {
             Destroy(gameObject);
         }
     }


}
