using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> currentInventory;
    [SerializeField] private PlayerInteraction playerInteraction;

    [SerializeField] private int maxInventorySize = 4;

    private int currentIndex = 0;

    public void AddItem(GameObject item)
    {
        currentInventory[currentIndex] = item;
    }

    public void RemoveItem(GameObject item)
    {
        var index = currentInventory.IndexOf(item);
        currentInventory[index] = null;
    }

    public void NextItem(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
         
            if (currentInventory[currentIndex] != null)
            {
                playerInteraction.HideItem(currentInventory[currentIndex]);
            }

            currentIndex++;

            if (currentIndex == maxInventorySize)
            {
                currentIndex = currentInventory.Count - 1;
            }
         

            if (currentInventory[currentIndex] != null)
            {
                playerInteraction.SetItem(currentInventory[currentIndex]);

            }
            else
            {
                playerInteraction.CanPick();
            }
        }
    }

    public void PreviousItem(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (currentInventory[currentIndex] != null)
            {
                playerInteraction.HideItem(currentInventory[currentIndex]);
            }

            currentIndex--;

            if (currentIndex < 0)
            {
                currentIndex = 0;
            }


            if (currentInventory[currentIndex] != null)
            {

                playerInteraction.SetItem(currentInventory[currentIndex]);

            }

            else
            {
                playerInteraction.CanPick();
            }
        }
    }
}
