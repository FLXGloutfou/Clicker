using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{

    public GameObject upgradewindow;
    private bool Upgradeisopen = false;

    public Text woodText;
    public Text moneyText;
    public Text woodPerMinuteText;
    public Text numberOfAutoText;
    public Text autoWoodCostText;
    public Text autoValueCostText;

    public void OpenUpgradeWindow()
    {
        if (Upgradeisopen != true)
        {
            upgradewindow.SetActive(true);
            Upgradeisopen = true;
        }
        else
        {
            upgradewindow.SetActive(false);
            Upgradeisopen = false;
        }
        
    }

    void Update()
    {
        woodText.text = Manager.Instance._wood.ToString();
        moneyText.text = Manager.Instance._money.ToString();
        woodPerMinuteText.text = Manager.Instance._woodPerMinute.ToString();
        numberOfAutoText.text = Manager.Instance._nombreOfAuto.ToString();
        autoWoodCostText.text = Manager.Instance._autoWoodCost.ToString();
        autoValueCostText.text = Manager.Instance._autoValueCost.ToString();
    }

}
