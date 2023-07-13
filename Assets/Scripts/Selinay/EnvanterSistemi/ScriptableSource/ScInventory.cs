using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Invertory", menuName = "Scriptable/Inventory")]

public class ScInventory : ScriptableObject
{
    public List<Slot> inventorySlots = new List<Slot>();
    int stackLimit = 10;

    public void DeleteItem(int index)
    {
        inventorySlots[index].isFull = false;
        inventorySlots[index].itemCount = 0;
        inventorySlots[index].item = null;
    }

    public void DropItem(int index, Vector3 position)
    {
        for (int i = 0; i < inventorySlots[index].itemCount; i++)
        {
            GameObject tempItem = Instantiate(inventorySlots[index].item.itemPrefabs);
            tempItem.transform.position = position + new Vector3(i, 0, 0);
        }

        DeleteItem(index);
    }

    public void OnPointerClicks(int index)
    {
        for (int i = 0; i < inventorySlots[index].itemCount; i--)
        {
            if (inventorySlots[index].item.itemName == "Meat")
            {
                UseItem(i);
            }
        }

    }
    
    public SCitem UseItem(int index)
    {
        SCitem tempScitem = inventorySlots[index].item;
        inventorySlots[index].itemCount--;
        if (inventorySlots[index].itemCount < 0)
            DeleteItem(index);

        return tempScitem;
    }

    public int GetItemCount(SCitem item)
    {
        int itemCount = 0;
        foreach (Slot slot in inventorySlots)
        {
            if (slot.item != null && slot.item.itemName == item.itemName)
            {
                itemCount = slot.itemCount;
            }
        }
        Debug.Log("Ýtem Count" + itemCount);
        return itemCount;
    }

    public bool AddItem(SCitem item)
    {
        if (item == null)
        {
            return false;
        }

        foreach (Slot slot in inventorySlots)
        {
            if (slot.item == item)
            {
                if (slot.item.canStackable)
                {
                    if (slot.itemCount < stackLimit)
                    {
                        slot.itemCount++;
                        if (slot.itemCount >= stackLimit)
                        {
                            slot.isFull = true;
                        }
                        return true;
                    }
                }
            }
            else if (slot.itemCount == 0)
            {
                slot.AddItemToSlot(item);
                return true;
            }
        }
        return false;
    }
}

[System.Serializable]
public class Slot
{
    public bool isFull;
    public int itemCount;
    public SCitem item;
    public void AddItemToSlot(SCitem item)
    {
        this.item = item;
        if (item.canStackable == false)
        {
            isFull = true;
        }
        itemCount++;
    }
    
}

