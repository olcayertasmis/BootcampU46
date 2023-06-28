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
        currentItem = item; //itemin sald�r� i�in mi ba�ka bir g�rev i�in mi al�nd���n� anlay�p kodlamak i�in gerekli
        if (temp)
        {
            Destroy(temp.gameObject);
        }
        temp =Instantiate(item, itemHolderPoint);
        temp.transform.localPosition = Vector3.zero;
    }
}
