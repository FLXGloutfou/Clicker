using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{
    public static Manager Instance;

    private void Awake()
    {
        if (Manager.Instance == null)
        {
            Manager.Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public int _wood = 0;
    public int _money = 0;
    public int _woodPerMinute;
    public int _nombreOfAuto;
    public int _autoWoodCost;
    public int _autoValueCost;
    

    private bool isAutoClicking = false;
    private int autoWoodValue;



    void Start ()
    {
        _nombreOfAuto = 0;
        autoWoodValue = 10;
        _autoWoodCost = 100;
        _autoValueCost = 100;
    }

    void Update()
    {

    }
    public void SetWood(int newAmount)
    {
        _wood = newAmount;
        //feedback
    }
    public void AddWood(int amount)
    {
        SetWood(_wood+amount);
    }


    public void ButtonSellWood()
    { 
        _money = _money + _wood * 10;
        _wood = 0;
    }

    public void ButtonAutoWood()
    {
        if (_money > _autoWoodCost)
        {
            _money -= _autoWoodCost;
            var tempAutoWood = (float)_autoWoodCost;
            tempAutoWood *= 1.5f;
            _autoWoodCost = (int)Mathf.Round(tempAutoWood);
  
            _nombreOfAuto++;
            if (!isAutoClicking)
            {
                StartCoroutine(createAutoClic());
            }
        }
        
    }

    public IEnumerator createAutoClic()
    {
        
        isAutoClicking = true;

        while (_nombreOfAuto > 0)
        {
            _woodPerMinute = _nombreOfAuto * autoWoodValue;
            AddWood(_woodPerMinute);
            yield return new WaitForSeconds(1f);
        }

        isAutoClicking = false;
    }



    public void AutoValueIncrease()
    {
        if (_money > _autoValueCost)
        {
            _money -= _autoValueCost;

            var tempAutoValue = (float)_autoValueCost;
            tempAutoValue *= 1.5f;
            _autoValueCost = (int)Mathf.Round(tempAutoValue);

            autoWoodValue += 10;
        }
    }
}

