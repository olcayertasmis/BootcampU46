using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionsItem : MonoBehaviour
{
    public GameObject currentItem;
   
    GameObject temp = null;// geçici bir deðiþken
    public void SetItem(GameObject item)
    {
        currentItem = item; //itemin saldýrý için mi baþka bir görev için mi alýndýðýný anlayýp kodlamak için gerekli
        if (temp)
        {

        }

    }
}
