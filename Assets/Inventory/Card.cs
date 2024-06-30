using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Inventory/Cards")]
public class Card : ScriptableObject
{
    public Sprite Item;
    public string title;
    public string description;
}
