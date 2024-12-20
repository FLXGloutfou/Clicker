using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class FurnitureManager : MonoBehaviour
{
    public List<FurnitureSlot> FurnitureSlots = new List<FurnitureSlot>(); 
    public GameObject SlotUIPrefab; 
    public Transform SlotsContainer; 

    public void InitializeSlots(int numberOfSlots)
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
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

        
        ui.transform.Find("Title").GetComponent<Text>().text = slot.Plan._name;
        ui.transform.Find("Cost").GetComponent<Text>().text = "Coût : " + slot.Plan._woodCost;
        //ui.transform.Find("Profit").GetComponent<Text>().text = "Vente : " + slot.Plan._sellValue;
        ui.transform.Find("Revenue").GetComponent<Text>().text = "Revenus : " + slot.Plan._revenuePerSecond + " / sec";

        Image icon = ui.transform.Find("Icon").GetComponent<Image>();
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
