using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RotatePlacement : MonoBehaviour
{

    private float rotation;
    private int currentRotation = 1;
    public string newRotation;

    void Update()
    {
        rotation = transform.rotation.z;


        if (Input.GetKey(KeyCode.R))
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentRotation += 1;
            }
        }
        if (currentRotation >= 5)
        {
            currentRotation = 1;
        }
        newRotation = Rotate();
    }

    string Rotate()
    {
        if (currentRotation == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 0));
            return "up";
        }
        if (currentRotation == 2)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 90));
            return "left";
        }
        if (currentRotation == 3)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 180));
            return "down";
        }
        if (currentRotation == 4)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 270));
            return "right";
        }
        return "up";
    }
}
