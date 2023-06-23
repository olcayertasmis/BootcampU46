using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Invertory", menuName = "Scriptable/Inventory")]
public class ScInventory : ScriptableObject
{
    public List<Slot> inventorySlots = new List<Slot>();
    int stackLimit = 10;
    public bool AddItem(SCitem item)
    {
        foreach (Slot slot in inventorySlots)
        {
            if(slot.item == item)
            {
                if (slot.item.canStackable)
                {
                    if(slot.itemCount < stackLimit)
                    {
                        slot.itemCount++;
                        if(slot.itemCount >= stackLimit)
                        {
                            slot.isFull = true;
                        }
                        return true;
                    }
                }
            }
            else if (slot.itemCount==0)
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

