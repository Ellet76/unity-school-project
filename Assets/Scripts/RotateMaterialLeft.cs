using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateMaterialLeft : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("passed OnTrigger");
        string dir = collision.GetComponent<MoveMaterial>().direction;
        if (dir == "up")
        {
            dir = "left";
        }
        else if (dir == "left")
        {
            dir = "down";
        }
        else if (dir == "down")
        {
            dir = "right";
        }
        else if (dir == "right")
        {
            dir = "up";
        }
        collision.GetComponent<MoveMaterial>().direction = dir;
    }
}