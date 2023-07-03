using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    public List<SlotUI> uiList = new List<SlotUI>();
    Inventory _userInventory;

    private void Start()
    {
        _userInventory = gameObject.GetComponent<Inventory>();
        //UpdateUI();
    }

    public void UpdateUI() //arayüz güncellemesi için 
    {
        for (int i = 0; i < uiList.Count; i++)
        {//Inventory scripti içindeki playerInventory ScýInventory scriptine ulaþýyor.
            {
                if (_userInventory.playerInventory.inventorySlots[i].itemCount > 0) //inventory içindeki elemanýn deðeri 0dan büyükse
                {
                    uiList[i].itemImage.sprite = _userInventory.playerInventory.inventorySlots[i].item.itemIcon;//inventory içindeki elemanýn item imajene eþitle

                    if (_userInventory.playerInventory.inventorySlots[i].item.canStackable)//eðer itemimiz stackleniyorsa text artsýn
                    {
                        uiList[i].itemCountText.gameObject.SetActive(true);//item text 
                        uiList[i].itemCountText.text = _userInventory.playerInventory.inventorySlots[i].itemCount.ToString();
                    }
                    else
                    {
                        uiList[i].itemCountText.gameObject.SetActive(false);//stacklenmiyorsa text kapansýn
                    }
                }
                else// envanterimizde hiçbir item yoksa herhangibir resim olmasýn.içinde biþey yoksa sayýda olmasýn.
                {
                    uiList[i].itemImage.sprite = null;
                    uiList[i].itemCountText.gameObject.SetActive(false);
                }
            }
        }
    }
}