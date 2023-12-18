using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_spawn : MonoBehaviour
{
    public static Enemy_spawn main;

    [SerializeField] private GameObject Enemy;
    [SerializeField] private int Enemy_number;
    [SerializeField] private float loop;
    private int count = 0;
    public GameObject enemy_sp;

    private void Awake()
    {
        main = this;

    }
    void Start()
    {
        float start = 0f;
        InvokeRepeating("spawn",start,loop);
    }
    private void spawn()
    {
        if (Enemy_number > count)
        {
            enemy_sp = Instantiate(Enemy, transform.position, Quaternion.identity);
            //enemy_spawn = Enemy_follow.main.EnemyPrefabs[Enemy_follow.main.selectedEnemy];
            count++;
        }  
        
    }
    
    
}
