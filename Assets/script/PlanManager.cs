using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanManager : MonoBehaviour
{

    //_____________________________________________________________________________//
    //VARIABLE//

    public List<FurniturePlanSO> _availablePlansList = new List<FurniturePlanSO>();
    public Text _blueprintNameText;
    public Text _blueprintCostText;
    public Text _blueprintSellValueText;
    public Text _blueprintWoodCostText;

    //public Image PlanIcon;
    public Button BuyPlanButton;

    private FurniturePlanSO _currentDisplayedBlueprint;


    //_____________________________________________________________________________//

    private void Start()
    {
        DisplayRandomPlan();
    }

    private void DisplayRandomPlan()
    {
        if (_availablePlansList.Count > 0)
        {
            _currentDisplayedBlueprint = _availablePlansList[Random.Range(0, _availablePlansList.Count)];

            
            _blueprintNameText.text = _currentDisplayedBlueprint._name;
            _blueprintSellValueText.text = "prix de revente: " + _currentDisplayedBlueprint._sellValue.ToString() + "Y";
            _blueprintCostText.text = "acheter le plan pour:\n" + _currentDisplayedBlueprint._blueprintCost.ToString() + "Y";
            _blueprintWoodCostText.text = "Coût en bois: " + _currentDisplayedBlueprint._woodCost;
            //PlanIcon.sprite = CurrentDisplayedPlan._icon;

            
            BuyPlanButton.interactable = true;
        }
        else
        {
            Debug.LogWarning("Aucun plan disponible dans la liste.");
        }
    }

    public void BuyDisplayedPlan()
    {
        if (Manager.Instance._money >= _currentDisplayedBlueprint._blueprintCost)
        {
            if (_currentDisplayedBlueprint != null)
            {
                bool assignmentSuccess = FurnitureManager.Instance.AssignPlanToSlot(_currentDisplayedBlueprint);

                if (assignmentSuccess)
                {
                    Manager.Instance._money -= _currentDisplayedBlueprint._blueprintCost;
                    DisplayRandomPlan();
                }
                else
                {
                    Manager.Instance.FeedBack("Pas de slot disponible");
                }
            }
        }
        else
        {
            Manager.Instance.FeedBack("Pas assez d'argent");
        }
    }
}