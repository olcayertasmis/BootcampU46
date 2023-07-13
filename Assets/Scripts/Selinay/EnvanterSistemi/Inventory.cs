using System;
using UnityEngine;


public class Inventory : MonoBehaviour 
{
    public event EventHandler OnItemUse;

    public ScInventory playerInventory;
    public PlayerActionsItem playerAction;

    InventoryUIController inventoryUI;

    public OpenDoor opend;

    bool isSwapping;
    int tempIndex;
    Slot tempSlot;
    private void Start()
    {

        inventoryUI = gameObject.GetComponent<InventoryUIController>();
        //inventoryUI.UpdateUI();

    }

    public int GetItemCount(Item item)
    {
        return playerInventory.GetItemCount(item.scitem);
    }

    public void onItemUse(Item item)
    {
        //Eðer kullanýlan itemýn SCFood bilgisi geliyorsa baþka bir þey yapmaya gerek yok bu tarafta
        Debug.Log(item);
        OnItemUse?.Invoke(this, EventArgs.Empty);
        Debug.Log(item.scitem.itemName);
    }

    //PLAYER SCRIPTI
    //void Start()
    //{
    //    inventory.playerInventory.OnItemUse += Player_OnItemUse;
    //}
    //private void Player_OnItemUse(object sender, System.EventArgs Meat)
    //{
    //    Item kullanýldý bilgisi için gerekli
    //}

    public void CurrentItem(int index)
    {
        if (playerInventory.inventorySlots[index].item)
        {
            playerAction.SetItem(playerInventory.inventorySlots[index].item.itemPrefabs);
        }

    }

    public void DeleteItem()
    {
        if (isSwapping == true)
        {
            playerInventory.DeleteItem(tempIndex);
            isSwapping = false;
            inventoryUI.UpdateUI();
        }
    }

    public void DropItem()
    {
        if (isSwapping == true)
        {
            playerInventory.DropItem(tempIndex, gameObject.transform.position + Vector3.forward);
            isSwapping = false;
            inventoryUI.UpdateUI();
        }
    }

    public void RightClick(int index)
    {
            playerInventory.UseItem(index);
            inventoryUI.UpdateUI();   
    }

    public void SwapItem(int index)
    {
        if (isSwapping == false)
        {
            tempIndex = index;
            tempSlot = playerInventory.inventorySlots[tempIndex];
            isSwapping = true;
        }
        else if (isSwapping == true)
        {
            playerInventory.inventorySlots[tempIndex] = playerInventory.inventorySlots[index];
            playerInventory.inventorySlots[index] = tempSlot;
            isSwapping = false;
        }

        inventoryUI.UpdateUI();
    }

    public void OnTriggerEnter(Collider other)
    {
        Item currentItem = other.gameObject.GetComponent<Item>();

        if (other.gameObject.CompareTag("Item"))
        {
            if (playerInventory.AddItem(currentItem.scitem))
            {
                Destroy(other.gameObject);
                inventoryUI.UpdateUI();
            }

        }

        bool taskType = currentItem.scitem.tasktype;
        if (taskType)
        {
            //Door ise yazýlacaklar
            if (currentItem.scitem.name == "Door")
            {
                int count = GetItemCount(currentItem);
                if (count == 5)
                {
                    OpenDoor doorScript = GetComponent<OpenDoor>();
                    doorScript.MoveRight();
                    doorScript.MoveLeft();
                    DeleteItem();
                }

            }           
            inventoryUI.UpdateUI();
        }
    }
}
