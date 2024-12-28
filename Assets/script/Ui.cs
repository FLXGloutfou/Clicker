using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    //_____________________________________________________________________________//
    //VARIABLE//
    public GameObject _upgradeWindow;
    private bool _upgradeisopen = false;
    public GameObject _shopWindow;
    private bool _shopWindowIsOpen = false;


    public Text _woodText;
    public Text _moneyText;
    public Text _woodPerMinuteText;
    public Text _numberOfAutoText;
    public Text _autoWoodCostText;
    public Text _autoValueCostText;

    //_____________________________________________________________________________//
    void Update()
    {
        _woodText.text = Manager.Instance._wood.ToString();
        _moneyText.text = Manager.Instance._money.ToString();
        //woodPerMinuteText.text = Manager.Instance._woodPerMinute.ToString();
        //numberOfAutoText.text = Manager.Instance._nombreOfAuto.ToString();
        _autoWoodCostText.text = "Acheter pour :\n" + Manager.Instance._autoLumberCost.ToString();
        _autoValueCostText.text = "Acheter pour :\n" + Manager.Instance._autoLumberToolCost.ToString();
    }

    public void OpenUpgradeWindow()
    {
        if (_upgradeisopen != true)
        {
            _upgradeWindow.SetActive(true);
            _upgradeisopen = true;
            if (_shopWindowIsOpen == true)
            {
                _shopWindow.SetActive(false);
                _shopWindowIsOpen = false;
            }
        }
        else
        {
            _upgradeWindow.SetActive(false);
            _upgradeisopen = false;
        }

    }
    public void OpenShopUpWindow()
    {
        if (_shopWindowIsOpen != true)
        {
            _shopWindow.SetActive(true);
            _shopWindowIsOpen = true;
            if (_upgradeisopen == true)
            {
                _upgradeWindow.SetActive(false);
                _upgradeisopen = false;
            }
        }
        else
        {
            _shopWindow.SetActive(false);
            _shopWindowIsOpen = false;
        }

    }

}
