using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFramrate : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }
}
