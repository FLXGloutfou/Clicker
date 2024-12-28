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
            Manager.Instance._wood -= _currentslot._plan._woodCost;

            
            _stockUI.text = _currentslot._plan._stock.ToString();
        }
        else
        {
            Debug.Log("pas assez de bois");
        }
    }

    private void UpdateSlotUI(FurnitureSlot slot)
    {
        _titleUi.text = slot._plan._name;
        _woodCostUi.text = slot._plan._woodCost.ToString();
        _stockUI.text = slot._plan._stock.ToString();

        _iconUI.sprite = slot._plan._icon;
    }
}
