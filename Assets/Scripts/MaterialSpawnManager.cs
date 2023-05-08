using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSpawnManager : MonoBehaviour
{
    bool materialsSpawning = true;
    int materialSpawnDelay = 1;
    public GameObject ironOre;
    public Transform importTile;
    
    
    void Start()
    {
        if (materialsSpawning)
        {
            StartCoroutine(Spawner());
        }
    }

    
    void Update()
    {

    }


    IEnumerator Spawner()
    {
        Instantiate(ironOre, importTile.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(materialSpawnDelay);
    }
}
