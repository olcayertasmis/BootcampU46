using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ScInventory playerInventory;
    public PlayerActionsItem playerAction;
    InventoryUIController inventoryUI;

    bool isSwapping;
    int tempIndex;
    Slot tempSlot;
    private void Start()
    {
        inventoryUI = gameObject.GetComponent<InventoryUIController>();
        //inventoryUI.UpdateUI();
    }
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if (playerInventory.AddItem(other.gameObject.GetComponent<Item>().item))
            {
                Destroy(other.gameObject);
                inventoryUI.UpdateUI();
            }

        }
    }


}
