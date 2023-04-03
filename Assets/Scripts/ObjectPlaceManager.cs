using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ObjectPlaceManager : MonoBehaviour
{
    public List<Tile> tiles;
    public Tilemap floor;
    public Tilemap machines;
    public Tilemap seePlacement;

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
        SeeTilePlace(tiles[machineSelection.value]);
        if (Input.GetMouseButtonUp(0) == true)
        {
            machineSelected = true;
        }
        if (machineSelected) 
        {
            PlaceTile(tiles[machineSelection.value]);
            machineSelected = false;
        }
    }

    void PlaceTile(Tile tile)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = floorMap.WorldToCell(mousePosition);
        if (floor.HasTile(gridPosition) && !machines.HasTile(gridPosition))
        {
            machines.SetTile(gridPosition, tile);
        }
        else if (machines.HasTile(gridPosition))
        {
            machines.SetTile(gridPosition, null);
        }
    }

    void SeeTilePlace(Tile tile)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = floorMap.WorldToCell(mousePosition);

        seePlacement.SetTile(gridPosition, tile);
        if (pastMousePos != gridPosition)
        {
            seePlacement.SetTile(pastMousePos, null);
        }
        pastMousePos = gridPosition;
    }
    
}
