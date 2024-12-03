using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public int wood;
    public int money;
    public Text woodText;
    public Text moneyText;

    void Start ()
    {
        money = 0;
        wood = 0;
    }

    void Update()
    {
        woodText.text = wood.ToString();
        moneyText.text = money.ToString();
    }

    public void AddWood(int amount)
    {
        wood += amount;
    }
}
