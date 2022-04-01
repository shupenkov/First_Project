using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private ListItems item;
    private ItemType itemType;

    public void SetImageOnItem(ItemType itemType)
    {
        this.itemType = itemType;
        image.sprite = item.GetItemByType(itemType);
    }
}
