using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialSpawnManager : MonoBehaviour
{
    // Declares variables

    public GameObject ironOre;
    public Transform importTile;
    private Coroutine test;
    
    void Start()
    {
        // starts Coroutine for materials
        test = StartCoroutine(Spawner());
    }

    
    void Update()
    {
        // Stops Coroutine of pressed G
        if (Input.GetKeyDown(KeyCode.G))
        {
            StopCoroutine(test);
        }
    }


    IEnumerator Spawner()
    {
        // Declares Coroutine
        for (;;)
        {
            Instantiate(ironOre, importTile.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);

        }
    }
}
