using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmeltOre : MonoBehaviour
{
    public GameObject ironBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("passed furnace trigger");
        if (collision.gameObject.tag == "Iron Ore")
        {
            Instantiate(ironBar, transform.position, Quaternion.identity);
            ironBar.GetComponent<MoveMaterial>().direction = collision.GetComponent<MoveMaterial>().direction;
            Destroy(collision.gameObject);
        }
    }

}
