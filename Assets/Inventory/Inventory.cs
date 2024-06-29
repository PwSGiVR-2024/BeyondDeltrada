using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
public class Inventory : ScriptableObject
{
    public static Inventory instance;

    public List<Item> items = new List<Item>();
    public int space = 4; // Inventory space, set to 4 as shown in your image

    public Action onItemChangedCallback;

    private void OnEnable()
    {
        // Ensures that we have only one instance of Inventory
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.LogWarning("Multiple instances of Inventory found!");
        }
    }

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }

        items.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}