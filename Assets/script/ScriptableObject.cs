using UnityEngine;


[CreateAssetMenu(fileName = "NewCraftableItem", menuName = "Crafting System/Craftable Item")]
public class CraftableItem : ScriptableObject
{
    public string itemName; 
    public int woodCost;    
    public int sellValue;   
    public Sprite itemImage; 
}