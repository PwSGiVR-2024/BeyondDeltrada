// Item.cs
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("Only Gameplay")]
    public string itemName;
    public Card itemCard;
    
    [Header("Only UI")]
    public Sprite icon;
}