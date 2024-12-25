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
    private int _shopLVLupPrize = 1000;

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
        if (Manager.Instance._money > _shopLVLupPrize)
        {
            if (CurentLVL < 5)
            {
                Manager.Instance._money -= _shopLVLupPrize;
                Shopsprite.sprite = ShopLVL[CurentLVL];
                FurnitureManager.UnlockSlot(CurentLVL);
                CurentLVL++;
            }
            else
            {
                Debug.Log("Boutique au niveau maximum.");
            }
        }
        else
        {
            Debug.Log("Pas assez d'argent.");
        }
    }
}
