using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

[CreateAssetMenu(menuName = "ScriptableObjects/InventoryItems")]

public class ListItems : ScriptableObject
{
    [SerializeField] private ItemsField[] itemImages;

    public Sprite GetItemByType(ItemType itemType)
    {
        return itemImages.First(x => x.itemType == itemType).image;
    }

}

public enum ItemType
{
    Key, Hammer, Flashlight
}

[Serializable]
public class ItemsField
{
    public ItemType itemType;
    public Sprite image;
}
