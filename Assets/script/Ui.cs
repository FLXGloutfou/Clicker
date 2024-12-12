using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{

    public GameObject upgradeWindow;
    private bool Upgradeisopen = false;
    public GameObject devWindow;
    private bool devisopen = false;
    public GameObject settingWindow;
    private bool settingisopen = false;


    public Text woodText;
    public Text moneyText;
    public Text woodPerMinuteText;
    public Text numberOfAutoText;
    public Text autoWoodCostText;
    public Text autoValueCostText;


    void Update()
    {
        woodText.text = Manager.Instance._wood.ToString();
        moneyText.text = Manager.Instance._money.ToString();
        woodPerMinuteText.text = Manager.Instance._woodPerMinute.ToString();
        numberOfAutoText.text = Manager.Instance._nombreOfAuto.ToString();
        autoWoodCostText.text = "Acheter pour :\n" + Manager.Instance._autoWoodCost.ToString();
        autoValueCostText.text = "Acheter pour :\n" + Manager.Instance._autoValueCost.ToString();
    }

    public void OpenUpgradeWindow()
    {
        if (Upgradeisopen != true)
        {
            upgradeWindow.SetActive(true);
            Upgradeisopen = true;
        }
        else
        {
            upgradeWindow.SetActive(false);
            Upgradeisopen = false;
        }

    }
    public void OpenDevWindow()
    {
        if (Upgradeisopen != true)
        {
            devWindow.SetActive(true);
            Upgradeisopen = true;
        }
        else
        {
            devWindow.SetActive(false);
            Upgradeisopen = false;
        }

    }

}
