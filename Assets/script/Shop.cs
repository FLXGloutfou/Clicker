using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shop : MonoBehaviour
{
    public FurnitureManager FurnitureManager;
    public SpriteRenderer Shopsprite;
    public Sprite[] ShopLVL;
    private int CurentLVL;

    void Start()
    {
        CurentLVL =  0;
        FurnitureManager.InitializeSlots(5);
    }

    public void AjouterPlan(FurniturePlanSO plan)
    {
        bool success = FurnitureManager.AssignPlanToSlot(plan);
        if (!success)
        {
            Debug.LogWarning("Pas de slot disponible pour le plan : " + plan._name);
        }
    }

    public void ShopLvlUp()
    {
        if (CurentLVL <= 4)
        {
            CurentLVL++;
            Shopsprite.sprite = ShopLVL[CurentLVL];
        }
        
    }
}
