using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class grid_build : MonoBehaviour
{
    public static grid_build main;

    private void Awake()
    {
        main = this;
    }


    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    private GameObject tower;
    private Color startColor;
    private bool ck2;
    private void Start()
    {
        startColor=sr.color;
    }
    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }
    private void OnMouseExit()
    {
        sr.color = startColor;
    }
    private void Update()
    {
        //Tower_shop.ck = ck2;
    }
    public void OnMouseDown()
    {
        if (tower != null) return;
        if (Tower_shop.ck == true)
        {
            
            Tower_shop._money -= 20;
        }
        GameObject towerToBuild = build.main.GetSelectedTower();
        tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);

    }
    


    /*
    public Tilemap tilemap; // Tilemap nesnesi
    public GameObject prefabToPlace; // Yerleþtirilecek prefab
    private GameObject tower;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);
            Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cellPosition);

            GameObject towerToBuild = build.main.GetSelectedTower();
            tower = Instantiate(towerToBuild, cellCenterPos, Quaternion.identity);
        }
    }
    */

}
