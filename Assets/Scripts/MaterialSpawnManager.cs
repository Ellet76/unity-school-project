using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialSpawnManager : MonoBehaviour
{
    public GameObject ironOre;
    public Transform importTile;
    private Coroutine test;
    
    void Start()
    {
        test = StartCoroutine(Spawner());
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StopCoroutine(test);
        }
    }


    IEnumerator Spawner()
    {
        for (;;)
        {
            Instantiate(ironOre, importTile.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);

        }
    }
}
