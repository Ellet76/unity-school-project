using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectPlaceManager : MonoBehaviour
{
    public List<GameObject> machines;
    public Transform parent;

    public Tilemap floor;
    private GridLayout floorMap;

    public TMP_Dropdown machineSelection;


    void Start()
    {
        floorMap = floor.GetComponent<GridLayout>();
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            try
            {
                PlaceObject(machines[machineSelection.value - 1]);
            }
            catch (System.Exception) 
            { }
        }    
    }


    Vector3Int ConvertMousePos()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = floorMap.WorldToCell(mousePosition);
        gridPosition.x = gridPosition.x + 1;
        gridPosition.y = gridPosition.y + 1;
        return gridPosition;
    }

    void PlaceObject(GameObject machine)
    {
        Vector3Int gridMousePosition = ConvertMousePos();
        Vector3Int realMousePos = floorMap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));


        if (floor.HasTile(realMousePos))
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(gridMousePosition.x, gridMousePosition.y), Vector2.up, 0f);
            if (hit.collider == null)
            {
                GameObject machineObject = Instantiate(machine, gridMousePosition, Quaternion.identity);
                machineObject.transform.SetParent(parent);
            }
        }
    }
}
