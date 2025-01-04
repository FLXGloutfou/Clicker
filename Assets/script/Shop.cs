using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //_____________________________________________________________________________//
    //VARIABLE//
    private int _currentLVL;
    private int _shopLVLupPrize = 1000;

    public SpriteRenderer _shopSprite;
    public Sprite[] _shopLVLSpriteList; 
    public Text _shopUpgradeCost;
    public Text _currentLVLUI;

    //_____________________________________________________________________________//
    void Start()
    {
        _currentLVL = 0;
        FurnitureManager.Instance.InitializeSlots(5);
    }

    private void Update()
    {
        _shopUpgradeCost.text = "LVL up for\n" + _shopLVLupPrize.ToString();
        _currentLVLUI.text = "LVL " + _currentLVL.ToString();
    }

    public void ShopLvlUp()
    {
        if (Manager.Instance._money > _shopLVLupPrize)
        {
            if (_currentLVL < 5)
            {
                _currentLVL++;
                Manager.Instance._money -= _shopLVLupPrize;
                _shopSprite.sprite = _shopLVLSpriteList[_currentLVL];
                FurnitureManager.Instance.UnlockSlot(_currentLVL - 1);
                _shopLVLupPrize += 5000 * _currentLVL;
            }
            else
            {
                Manager.Instance.FeedBack("Boutique LVL MAX");
            }
        }
        else
        {
            Manager.Instance.FeedBack("Pas assez d'argent");
        }
    }
}
