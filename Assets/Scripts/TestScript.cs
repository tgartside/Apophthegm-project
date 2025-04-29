using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
   public InventoryManager inventoryManager;
    public Item itemToPickup;

    public void PickupItem(int id)
    {
        inventoryManager.AddItem(itemToPickup);
    }
}
