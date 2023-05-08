using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;


public class ObjectPlaceManager2 : MonoBehaviour
{
    public List<Tile> tiles;
    public Tilemap floor;
    public Tilemap machines;
    public Tilemap seePlacement;
    public Tilemap allowPlacement;

    private GridLayout floorMap;
    private GridLayout machineMap;

    public TMP_Dropdown machineSelection;
    private bool machineSelected = false;

    private Vector3Int pastMousePos = new Vector3Int(0, 0, 0);

    void Start()
    {
        floorMap = floor.GetComponent<GridLayout>();
        machineMap = machines.GetComponent<GridLayout>();
    }

    void Update()
    {
        rotation();
        try
        {
            SeeTilePlace(tiles[machineSelection.value - 1]);
        }
        catch (System.Exception)
        {}
        if (Input.GetMouseButtonUp(0) == true)
        {
            machineSelected = true;
        }
        if (machineSelected) 
        {
            try
            {
                PlaceTile(tiles[machineSelection.value - 1]);
            }
            catch (System.Exception)
            {}
            machineSelected = false;
        }
    }

    void PlaceTile(Tile tile)
    {
        Vector3Int gridMousePosition = ConvertMousePos();
        if (!allowPlacement.HasTile(gridMousePosition))
        {
            if (floor.HasTile(gridMousePosition) && !machines.HasTile(gridMousePosition))
            {
                machines.SetTile(gridMousePosition, tile);
            }
            else if (machines.HasTile(gridMousePosition))
            {
                machines.SetTile(gridMousePosition, null);
            }
        }
    }

    void SeeTilePlace(Tile tile)
    {
        Vector3Int gridMousePosition = ConvertMousePos();
        if (floor.HasTile(gridMousePosition) && !machines.HasTile(gridMousePosition))
        {
            seePlacement.SetTile(gridMousePosition, tile);
            
        }
        if (pastMousePos != gridMousePosition)
        {
            seePlacement.SetTile(pastMousePos, null);
        }
        pastMousePos = gridMousePosition;
    }

    void rotation()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3Int gridMousePosition = ConvertMousePos();

            Quaternion pastRotation = machines.GetTransformMatrix(gridMousePosition).rotation;
            Vector3 newAngle = pastRotation.eulerAngles;
            newAngle.z = newAngle.z + 90;
            Quaternion newRotation = Quaternion.Euler(newAngle);

            Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, newRotation, Vector3.one);
            machines.SetTransformMatrix(gridMousePosition, matrix);
        }
    }

    Vector3Int ConvertMousePos()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = floorMap.WorldToCell(mousePosition);
        return gridPosition;
    }
}
