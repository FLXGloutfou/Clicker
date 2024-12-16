using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public FurnitureManager FurnitureManager;
    
    void Start()
    {
        FurnitureManager.InitializeSlots(3);
    }

    public void AjouterPlan(FurniturePlanSO plan)
    {
        bool success = FurnitureManager.AssignPlanToSlot(plan);
        if (!success)
        {
            Debug.LogWarning("Pas de slot disponible pour le plan : " + plan._name);
        }
    }
}
