using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCraft : MonoBehaviour
{
    private FurnitureSlot _currentslot;
    public Text _titleUi;
    public Text _woodCostUi;
    public Text _stockUI;
    public Image _iconUI;

    private bool _isSelling = false;

    public void CurrentSlot(FurnitureSlot slot)
    {  
        UpdateSlotUI(slot);
        _currentslot = slot;
    }
    public void CraftItem()
    {
        if (Manager.Instance._wood > _currentslot._plan._woodCost)
        {
            _currentslot._plan._stock += 10;
            Manager.Instance._wood -= _currentslot._plan._woodCost * 10;
            _stockUI.text = "stock:\n" + _currentslot._plan._stock.ToString();

            if (!_isSelling)
            {    
                StartCoroutine(SellFromStock());
            }
            
        }
        else
        {
            Manager.Instance.FeedBack("Pas assez de bois");
        }
    }

    public IEnumerator SellFromStock()
    {
        _isSelling = true;
        while (_currentslot._plan._stock > 0)
        {
            _currentslot._plan._stock--;
            _stockUI.text = "stock:\n" + _currentslot._plan._stock.ToString();
            Manager.Instance._money += _currentslot._plan._sellValue;
            yield return new WaitForSeconds(1f);
        }
        _isSelling = false;
    }

    private void UpdateSlotUI(FurnitureSlot slot)
    {
        slot._plan._stock = 0;
        _titleUi.text = slot._plan._name;
        _woodCostUi.text = "cout en bois par unité:\n" + slot._plan._woodCost.ToString();
        _stockUI.text = "stock:\n" + slot._plan._stock.ToString();

        _iconUI.sprite = slot._plan._icon;
    }
}
