using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Moneytext : MonoBehaviour
{
    public GameObject moneyManager;
    private TextMeshProUGUI text;
    private string money;
    private void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        money = moneyManager.GetComponent<MoneyManager>().money.ToString();
    }

    private void Update()
    {
        money = moneyManager.GetComponent<MoneyManager>().money.ToString();
        text.SetText(money);
    }


}
