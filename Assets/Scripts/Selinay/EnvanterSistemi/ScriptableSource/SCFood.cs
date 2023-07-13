using JetBrains.Annotations;
using UnityEngine;
using static Inventory;

[CreateAssetMenu(fileName = "FoodItem", menuName = "Scriptable/Food")]
public class SCFood : SCitem
{
    public float jumpHeight = 3f;
    public void FoodItem÷zellikleri(Inventory other)
    {
        Item currentItem = other.gameObject.GetComponent<Item>();
        bool foodType = currentItem.scitem.foodtype;
        if (foodType)
        {
            if (currentItem.scitem.name == "Meat")
            {
                jumpHeight += 10;
            }
        }
    }

}