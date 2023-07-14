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

    public void UpdateUI() //aray�z g�ncellemesi i�in 
    {
        for (int i = 0; i < uiList.Count; i++)
        {//Inventory scripti i�indeki playerInventory Sc�Inventory scriptine ula��yor.
            {
                if (_userInventory.playerInventory.inventorySlots[i].itemCount > 0) //inventory i�indeki eleman�n de�eri 0dan b�y�kse
                {
                    uiList[i].itemImage.sprite = _userInventory.playerInventory.inventorySlots[i].item.itemIcon;//inventory i�indeki eleman�n item imajene e�itle

                    if (_userInventory.playerInventory.inventorySlots[i].item.canStackable)//e�er itemimiz stackleniyorsa text arts�n
                    {
                        uiList[i].itemCountText.gameObject.SetActive(true);//item text 
                        uiList[i].itemCountText.text = _userInventory.playerInventory.inventorySlots[i].itemCount.ToString();
                    }
                    else
                    {
                        uiList[i].itemCountText.gameObject.SetActive(false);//stacklenmiyorsa text kapans�n
                    }
                }
                else// envanterimizde hi�bir item yoksa herhangibir resim olmas�n.i�inde bi�ey yoksa say�da olmas�n.
                {
                    uiList[i].itemImage.sprite = null;
                    uiList[i].itemCountText.gameObject.SetActive(false);
                }

            }
        }

    }

    public void InventoryItemInfo(int i)
    {

        if (_userInventory.playerInventory.inventorySlots[i].itemCount > 0)
        {
            uiList[i].itemNameText.text = _userInventory.playerInventory.inventorySlots[i].item.itemName;
            //uiList[i].itemNameText.gameObject.SetActive(false);
            uiList[i].itemDescriptionText.text = _userInventory.playerInventory.inventorySlots[i].item.itemDescription;
            //uiList[i].itemDescriptionText.gameObject.SetActive(false);          
            
        }
        else
        {
            uiList[i].itemNameText.text = null;
            uiList[i].itemDescriptionText.text = null;
            uiList[i].itemNameText.gameObject.SetActive(false);
            uiList[i].itemDescriptionText.gameObject.SetActive(false);

        }

    }


}