using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class FurnitureManager : MonoBehaviour
{

    public static FurnitureManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //_____________________________________________________________________________//
    //VARIABLE//
    public List<FurnitureSlot> _furnitureSlotsList = new List<FurnitureSlot>(); 
    public GameObject _slotUIPrefab; 
    public Transform _slotsContainer;

    //_____________________________________________________________________________//
    public void InitializeSlots(int numberOfSlots)
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject newSlotUI = Instantiate(_slotUIPrefab, _slotsContainer);
            newSlotUI.SetActive(false);
            FurnitureSlot newSlot = new FurnitureSlot
            {   
                _isOccupied = false,
                _uIObject = newSlotUI
            };
            _furnitureSlotsList.Add(newSlot);
        }
    }

    public void UnlockSlot(int slotIndex)
    {
        if (slotIndex < _furnitureSlotsList.Count && slotIndex >= 0)
        {
            _furnitureSlotsList[slotIndex]._uIObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Index de slot invalide ou déjà débloqué.");
        }
    }

    public bool AssignPlanToSlot(FurniturePlanSO plan)
    {
        foreach (var slot in _furnitureSlotsList)
        {
            if (!slot._isOccupied && slot._uIObject.activeSelf)
            {
                slot._plan = plan;
                slot._isOccupied = true;

                ItemCraft itemCraft = slot._uIObject.GetComponent<ItemCraft>();
                if (itemCraft != null)
                {
                    itemCraft.CurrentSlot(slot);
                }
                else
                {
                    Debug.LogWarning("ItemCraft n'est pas attaché à ce slot !");
                }
                return true;
            }

        }
        Debug.LogWarning("Aucun slot débloqué disponible pour ce plan.");
        return false;
    }

}
