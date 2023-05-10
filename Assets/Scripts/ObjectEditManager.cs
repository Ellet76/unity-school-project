using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectEditManager : MonoBehaviour
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
        
        if (machineSelection.options[machineSelection.value].text ==  "Edit")
        {
            if (Input.GetMouseButton(0) == true)
            {
                Debug.Log("Recognized Button press");
                DeleteMachine();
            }
            if (Input.GetKeyDown(KeyCode.R) == true)
            {

            }
        }
    }

    void DeleteMachine()
    {
        Vector3Int gridMousePosition = ConvertMousePos();
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(gridMousePosition.x + 1, gridMousePosition.y + 1), Vector2.up, 0f);
        if (hit.collider != null)
        {
            Destroy(hit.collider.gameObject);
        }
    }

    void Rotation()
    {
        Vector3Int gridMousePosition = ConvertMousePos();
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(gridMousePosition.x + 1, gridMousePosition.y + 1), Vector2.up, 0f);
        if (hit.collider != null)
        {
            GameObject machine = hit.collider.gameObject;
            Quaternion pastRotation = machine.transform.rotation;
            Vector3 newAngle = pastRotation.eulerAngles;
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                newAngle.z += 90;
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                newAngle.z -= 90;
            }
            machine.transform.rotation = Quaternion.Euler(newAngle);
        }
    }

    Vector3Int ConvertMousePos()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = floorMap.WorldToCell(mousePosition);
        return gridPosition;
    }
}
