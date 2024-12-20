using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{

    public GameObject upgradeWindow;
    private bool Upgradeisopen = false;
    public GameObject shopUpgrade;
    private bool shopUpgradeIsOpen = false;


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
        //woodPerMinuteText.text = Manager.Instance._woodPerMinute.ToString();
        //numberOfAutoText.text = Manager.Instance._nombreOfAuto.ToString();
        autoWoodCostText.text = "Acheter pour :\n" + Manager.Instance._autoWoodCost.ToString();
        autoValueCostText.text = "Acheter pour :\n" + Manager.Instance._autoValueCost.ToString();
    }

    public void OpenUpgradeWindow()
    {
        if (Upgradeisopen != true)
        {
            upgradeWindow.SetActive(true);
            Upgradeisopen = true;
            if (shopUpgradeIsOpen == true)
            {
                shopUpgrade.SetActive(false);
                shopUpgradeIsOpen = false;
            }
        }
        else
        {
            upgradeWindow.SetActive(false);
            Upgradeisopen = false;
        }

    }
    public void OpenShopUpWindow()
    {
        if (shopUpgradeIsOpen != true)
        {
            shopUpgrade.SetActive(true);
            shopUpgradeIsOpen = true;
            if (Upgradeisopen == true)
            {
                upgradeWindow.SetActive(false);
                Upgradeisopen = false;
            }
        }
        else
        {
            shopUpgrade.SetActive(false);
            shopUpgradeIsOpen = false;
        }

    }

}
