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
    public GameObject rotation;
    

    public Tilemap floor;
    private GridLayout floorMap;

    public TMP_Dropdown machineSelection;

    public GameObject moneyManager;


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
                if (moneyManager.GetComponent<MoneyManager>().allowSpending)
                {
                    PlaceObject(machines[machineSelection.value - 1]);
                }
            }
            catch (System.Exception) 
            { }
        }    
    }


    Vector3Int ConvertMousePos()
    {
        //Gets the mouse position from the screen and converts it to world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = floorMap.WorldToCell(mousePosition);
        gridPosition.x = gridPosition.x + 1;
        gridPosition.y = gridPosition.y + 1;
        return gridPosition;
    }

    void PlaceObject(GameObject machine)
    {
        //Mouse position form the grid
        Vector3Int gridMousePosition = ConvertMousePos();
        
        //Acual mouse position
        Vector3Int realMousePos = floorMap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        //Checks if the position is possible to place at 
        if (floor.HasTile(realMousePos))
        {
            //Checks if there is already something there
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(gridMousePosition.x, gridMousePosition.y), Vector2.up, 0f);
            if (hit.collider == null)
            {
                if (!CheckMouseUI.isMouseOverUIElement)
                {
                    GameObject machineObject = Instantiate(machine, gridMousePosition, Quaternion.identity);
                    machineObject.transform.SetParent(parent);
                    moneyManager.GetComponent<MoneyManager>().money = moneyManager.GetComponent<MoneyManager>().money - 10;
                    machineObject.transform.rotation = rotation.transform.rotation;
                }
            }
        }
    }

    bool CheckUI()
    {
        return true;
    }
}
