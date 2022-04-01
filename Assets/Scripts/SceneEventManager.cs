using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class SceneEventManager
{
    public static event Action<ItemType> OnPickItem;
    public static void TriggerOnPickItem(ItemType item) => OnPickItem?.Invoke(item);

    public static event Func<ItemType, bool> OnCheckedItemInInventory;
    public static bool TriggerOnCheckedItemInInventory(ItemType item) => OnCheckedItemInInventory.Invoke(item);
    
}
