using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainCameraMovement : MonoBehaviour
{
    Vector3 targetPosition;
    float movementSpeed = 10;

    void Start()
    {
        
    }

    void Update()
    {
        float step = movementSpeed * Time.deltaTime;
        float AD = Input.GetAxis("Horizontal");
        float WS = Input.GetAxis("Vertical");
        
        targetPosition = new Vector3(gameObject.transform.position.x + AD, gameObject.transform.position.y + WS, -10);
        if (targetPosition.y >= 25 || targetPosition.y <= -25)
        {
            targetPosition.y = targetPosition.y - (targetPosition.y/25);
        }
        if (targetPosition.x >= 25 || targetPosition.x <= -25)
        {
            targetPosition.x = targetPosition.x - (targetPosition.x / 25);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }

}
