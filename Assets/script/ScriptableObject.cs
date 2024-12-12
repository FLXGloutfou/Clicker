using UnityEngine;


[CreateAssetMenu(fileName = "NewCraftableItem", menuName = "Crafting System/Craftable Item")]
public class CraftableItem : ScriptableObject
{
    public string itemName; // Nom de l'objet
    public int woodCost;    // Prix en bois
    public int sellValue;   // Valeur de vente
    public Sprite itemImage; // Image de l'objet
}