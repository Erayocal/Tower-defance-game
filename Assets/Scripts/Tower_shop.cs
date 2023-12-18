using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_shop : MonoBehaviour
{
    public static Tower_shop main;
    [SerializeField] private float money;
    public static bool ck = false;
    public static float _money;
    void Update()
    {
        //money=_money;
    }
    private void Start()
    {
        _money=money;
    }
    private void Awake()
    {
        main = this;
    }
    private void OnMouseEnter()
    {
        if (CompareTag("build"))
        {
            if (_money >= 20)
            {
                ck = true;
            }
        }
    }
    private void OnMouseExit()
    {
        ck= false;
    }

    
}
