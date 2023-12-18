using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy_follow : MonoBehaviour
{
    [SerializeField] private GameObject bulletp;
    public Transform bulletPos;
    private float timer;
    public Animator animator;
    public static Enemy_follow main;
    [SerializeField] LayerMask tarrgetLayer;
    [SerializeField] public float rayDis = 1f;
    
    private void Awake()
    {
        main = this;
        
    }
    private void Start()
    {
        animator= GetComponent<Animator>();
        

    }
    public Transform target;
    void Update()
    {
        if (target == null)
        {
            Findenemy();
            return;
        }
        RotateTowardsTarget();
        
        if (!ck())
        {
            target = null;
            animator.SetBool("fire", false);
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                shoot();
            }
        }
    }
    private void shoot()
    {
        GameObject bullet= Instantiate(bulletp, bulletPos.position, Quaternion.identity);
        Tower_shoot bull=bullet.GetComponent<Tower_shoot>();
        bull.SetTarget(target);
        animator.SetBool("fire", true);
    }
    public void Findenemy()
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, rayDis, (Vector2)transform.position, 0f, tarrgetLayer);
        if(hit.Length > 0 ) { target = hit[0].transform; }

    }
    public bool ck()
    {
        return Vector2.Distance(target.position, transform.position)<=rayDis;
    }
    private void RotateTowardsTarget()
    {
         float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
         Quaternion newRotation = Quaternion.Euler(0f, 0f, angle);
         transform.rotation = newRotation;
         
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color= Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward,rayDis);
    }
    
}
