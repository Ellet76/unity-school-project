using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMaterialRight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Passed trigger");
        string dir = collision.GetComponent<MoveMaterial>().direction;
        if (dir == "up")
        {
            dir = "right";
        }
        else if (dir == "right")
        {
            dir = "down";
        }
        else if (dir == "down")
        {
            dir = "left";
        }
        else if (dir == "left")
        {
            dir = "up";
        }
        collision.GetComponent<MoveMaterial>().direction = dir;
    }
}
