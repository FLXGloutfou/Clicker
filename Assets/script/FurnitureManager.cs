using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FurnitureManager : MonoBehaviour
{
    public List<FurnitureSlot> FurnitureSlots = new List<FurnitureSlot>();
    public GameObject SlotUIPrefab; 
    public Transform SlotsContainer;

    public Text _planNameText;
    public Text _WoodCostText;
    public Text _RevenueText;
    public Image _FurnitureIconeText;


    public void InitializeSlots(int numberOfSlots)
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            Debug.Log("slot" + i);
            GameObject newSlotUI = Instantiate(SlotUIPrefab, SlotsContainer);
            FurnitureSlot newSlot = new FurnitureSlot
            {
                IsOccupied = false,
                UIObject = newSlotUI
            };
            FurnitureSlots.Add(newSlot);
        }
    }

    public bool AssignPlanToSlot(FurniturePlanSO plan)
    {
        foreach (var slot in FurnitureSlots)
        {
            if (!slot.IsOccupied)
            {
                slot.Plan = plan;
                slot.IsOccupied = true;
                UpdateSlotUI(slot);
                return true;
            }
        }
        return false;
    }


    private void UpdateSlotUI(FurnitureSlot slot)
    {
        GameObject ui = slot.UIObject;

        _planNameText.text = slot.Plan._name;
        _WoodCostText.text = "Coût : " + slot.Plan._woodCost;
        //ui.transform.Find("Profit").GetComponent<Text>().text = "Vente : " + slot.Plan._sellValue;
        _RevenueText.text = "Revenus : " + slot.Plan._revenuePerSecond + " / sec";

        Image icon = _FurnitureIconeText;
        if (icon != null && slot.Plan._icon != null)
        {
            icon.sprite = slot.Plan._icon;
        }
    }


    private void Start()
    {
        StartCoroutine(UpdateRevenueUI());
    }

    private IEnumerator UpdateRevenueUI()
    {
        while (true)
        {
            foreach (var slot in FurnitureSlots)
            {
                if (slot.IsOccupied)
                {
                    UpdateSlotUI(slot);
                }
            }
            yield return new WaitForSeconds(1);
        }
    }
}