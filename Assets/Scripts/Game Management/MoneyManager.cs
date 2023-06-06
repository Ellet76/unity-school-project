using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int money = 0;
    public bool allowSpending;


    private void Update()
    {
        // Checks if there is enough currency to place structures

        if (money < 10)
        {
            allowSpending = false;
        }
        if (money > 10 )
        {
            allowSpending = true;
        }
    }

}
