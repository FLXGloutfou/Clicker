using UnityEngine;

[CreateAssetMenu(fileName = "NewFurniturePlan", menuName = "Furniture Plan", order = 1)]
public class FurniturePlanSO : ScriptableObject
{
    public string _name; 
    public int _woodCost; 
    public int _sellValue; 
    public int _blueprintCost;
    public int _stock; 
    public Sprite _icon; 
}