using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellMaterial : MonoBehaviour
{
    public GameObject MoneyManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Passed trigger sell");
        Destroy(collision.gameObject);

        MoneyManager.GetComponent<MoneyManager>().money += 1;
    }
}
