using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainCameraMovement : MonoBehaviour
{
    // Declares variables
    private Vector3 targetPosition;
    private float movementSpeed = 10;
    private float step;


    void Update()
    {
        // Gets input for camera movement

        step = Time.deltaTime * movementSpeed;
        float AD = Input.GetAxis("Horizontal");
        float WS = Input.GetAxis("Vertical");
        
        // Moves camera
        targetPosition = new Vector3(transform.position.x + AD, transform.position.y + WS, -10);


    }

    private void LateUpdate()
    {
        // Checks border collission for camera
        if (targetPosition.y >= 25)
        {
            targetPosition = new Vector3(targetPosition.x, 25, -10);
        }
        if (targetPosition.x >= 25)
        {
            targetPosition = new Vector3(25, targetPosition.y, -10);
        }
        if (targetPosition.y <= -25)
        {
            targetPosition = new Vector3(targetPosition.x, -25, -10);
        }
        if (targetPosition.x <= -25)
        {
            targetPosition = new Vector3(-25, targetPosition.y, -10);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

    }

}
