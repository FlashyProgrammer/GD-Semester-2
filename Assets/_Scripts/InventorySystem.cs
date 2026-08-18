using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> currentInventory;
    [SerializeField] private PlayerInteraction playerInteraction;

    [SerializeField] private int maxInventorySize = 4;

    private int currentIndex = 0;

    private void Update()
    {
        switch (currentIndex)
        {
            case 0:
                playerInteraction.SetItem(currentInventory[0]);
                break;
            case 1:
                playerInteraction.SetItem(currentInventory[1]);
                break;
            case 2:
                playerInteraction.SetItem(currentInventory[2]);
                break;
            case 3:
                playerInteraction.SetItem(currentInventory[3]);
                break;
        }

        if(currentIndex >= maxInventorySize)
        {
            currentIndex = 0;
        }   
    }

    public void nextItem()
    {
        currentIndex++;

    }
    public void AddItem(GameObject item)
    {
        currentInventory.Add(item);
    }

    public void RemoveItem(GameObject item)
    {
        currentInventory.Remove(item);
    }
}
