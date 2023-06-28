using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionsItem : MonoBehaviour
{
    public GameObject currentItem;
    public Transform itemHolderPoint;
    GameObject temp = null;
    public void SetItem(GameObject item)
    {
        currentItem = item; //itemin saldýrý için mi baþka bir görev için mi alýndýðýný anlayýp kodlamak için gerekli
        if (temp)
        {
            Destroy(temp.gameObject);
        }
        temp =Instantiate(item, itemHolderPoint);
        temp.transform.localPosition = Vector3.zero;
    }
}
