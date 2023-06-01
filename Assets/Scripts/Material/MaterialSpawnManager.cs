using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialSpawnManager : MonoBehaviour
{
    // Declares variables

    public GameObject ironOre;
    public Transform importTile;
    private Coroutine coroutine;
    private bool activeCoroutine = false;
    
    void Start()
    {
        // starts Coroutine for materials
        coroutine = StartCoroutine(Spawner());
        activeCoroutine = true;
    }

    
    void Update()
    {
        // Stops Coroutine when time paused and starts when time starts
        if (!PauseTime.timeActive)
        {
            StopCoroutine(coroutine);
            activeCoroutine = false;
        }
        if (PauseTime.timeActive && !activeCoroutine)
        {
            coroutine = StartCoroutine(Spawner());
            activeCoroutine = true;
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
