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


        if (Input.GetKey(KeyCode.R) == true)
        {
            Rotation();
        }
    }



    void Rotation()
    {
        //Gets mouse position
        Vector3Int gridMousePosition = ConvertMousePos();
        LayerMask mask = LayerMask.GetMask("Machines");


        //Checks for object at position
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(gridMousePosition.x + 1, gridMousePosition.y + 1), Vector2.up, 0f, mask);
        if (hit.collider != null)
        {
            //Gets the angles for object
            GameObject machine = hit.collider.gameObject;
            Quaternion pastRotation = machine.transform.rotation;
            Vector3 newAngle = pastRotation.eulerAngles;

            //Rotates object
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                newAngle.z += 90;

                Debug.Log("Rotation Succesful");
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                newAngle.z -= 90;
                Debug.Log("Rotation Succesful");
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
