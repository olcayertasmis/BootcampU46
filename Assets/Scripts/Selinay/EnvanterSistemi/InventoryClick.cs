using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryClick : MonoBehaviour
{
    [SerializeField] GameObject userInventory;
    bool isInventoryOpen;
    
    void Start()
    {
        userInventory.SetActive(false);
    }   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(isInventoryOpen == false) 
            {
                userInventory.SetActive(true);
                isInventoryOpen = true;
            }
            else if (isInventoryOpen == true)
            {
                userInventory.SetActive(false);
                isInventoryOpen = false;
            }
            userInventory.SetActive(true);
        }
    }
}
