using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMaterial : MonoBehaviour
{
    public string direction;
    private float materialSpeed = 0.01f;

    
    
    void Update()
    {
        Vector3 directionVector = InterpertDirection();
        transform.position = new Vector3(materialSpeed*directionVector.x + transform.position.x, materialSpeed*directionVector.y + transform.position.y);
        
    }

    Vector2 InterpertDirection ()
    {
        if (CheckConveyer())
        {
            if (direction == "up")
            {
                return new Vector3(0, 1f);
            }
            else if (direction == "left")
            {
                return new Vector3(-1f, 0);
            }
            else if (direction == "down")
            {
                return new Vector3(0, -1f);
            }
            else if (direction == "right")
            {
                return new Vector3(1f, 0);
            }
        }
        return new Vector3(0, 0);
    }

    bool CheckConveyer ()
    {
        LayerMask mask = LayerMask.GetMask("Machines");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0f, mask);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}
