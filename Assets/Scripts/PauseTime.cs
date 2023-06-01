using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTime : MonoBehaviour
{
    public static bool timeActive = false;

    public void changeTimeState()
    {
        if (timeActive)
        {
            timeActive = false;
        }
        else if (!timeActive)
        {
            timeActive = true;
        }
    }
}
