using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCitem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public bool canStackable; //Nesnemiz stacklenebiliyor mu?
    public Sprite itemIcon;
    public GameObject itemPrefabs;
}
