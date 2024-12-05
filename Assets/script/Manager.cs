using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public int wood;
    public Text woodText;

    public int money;
    public Text moneyText;

    public int woodPerMinute;
    public Text woodPerMinuteText;

    private int nombreOfAuto;
    public Text numberOfAutoText;


    
    private bool isAutoClicking = false;
    private int autoWoodValue;
    private int autoWoodCost;



    void Start ()
    {
        money = 0;
        wood = 0;
        nombreOfAuto = 0;
        autoWoodValue = 10;
        autoWoodCost = 100;
    }

    void Update()
    {
        woodText.text = wood.ToString();
        moneyText.text = money.ToString();
        woodPerMinuteText.text = woodPerMinute.ToString();
        numberOfAutoText.text = nombreOfAuto.ToString();

    }

    public void AddWood(int amount)
    {
        wood += amount;
    }


    public void ButtonAutoWood()
    {
        if (wood > autoWoodCost)
        {
            autoWoodCost *= 2;
            wood -= autoWoodCost;
            nombreOfAuto++;
            if (!isAutoClicking)
            {
                StartCoroutine(createAutoClic());
            }
        }
        
    }

    public IEnumerator createAutoClic()
    {
        
        isAutoClicking = true;

        while (nombreOfAuto > 0)
        {
            woodPerMinute = nombreOfAuto * autoWoodValue;
            AddWood(woodPerMinute);
            yield return new WaitForSeconds(1f);
        }

        isAutoClicking = false;
    }
}

