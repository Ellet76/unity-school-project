using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectDeleteManager : MonoBehaviour
{
    public Tilemap floor;
    private GridLayout floorMap;

    public TMP_Dropdown machineSelection;
    void Start()
    {
        floorMap = floor.GetComponent<GridLayout>();
    }

    void Update()
    {
        if (machineSelection.options[machineSelection.value].text == "Edit")
        {

            if (Input.GetMouseButton(0) == true)
            {
                DeleteMachine();
            }
        }
    }

    void DeleteMachine()
    {
        //Gets mouse position
        Vector3Int gridMousePosition = ConvertMousePos();

        //Checks for objects at position
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(gridMousePosition.x + 1, gridMousePosition.y + 1), Vector2.up, 0f);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Import" || hit.collider.gameObject.tag != "Export")
            {

            }

            //Deletes object 
            Destroy(hit.collider.gameObject);
        }
    }

    Vector3Int ConvertMousePos()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = floorMap.WorldToCell(mousePosition);
        return gridPosition;
    }
}