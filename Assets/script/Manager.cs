using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public int money;
    public Text moneyText;
    void Start ()
    {
        money = 0;
    }

    void Update()
    {
        moneyText.text = money.ToString();
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }
}
