using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    public List<SlotUI> uiList = new List<SlotUI>();
    private Inventory _userInventory;

    private void Start()
    {
        _userInventory = gameObject.GetComponent<Inventory>();
        //UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < uiList.Count; i++)
        {
            if (_userInventory.playerInventory.inventorySlots[i].itemCount > 0)
            {
                uiList[i].itemImage.sprite = _userInventory.playerInventory.inventorySlots[i].item.itemIcon;

                if (_userInventory.playerInventory.inventorySlots[i].item.canStackable)
                {
                    uiList[i].itemCountText.gameObject.SetActive(true);
                    uiList[i].itemCountText.text = _userInventory.playerInventory.inventorySlots[i].itemCount.ToString();
                }
                else
                {
                    uiList[i].itemCountText.gameObject.SetActive(false);
                }
            }
            else
            {
                uiList[i].itemImage.sprite = null;
                uiList[i].itemCountText.gameObject.SetActive(false);
            }
        }
    }
}