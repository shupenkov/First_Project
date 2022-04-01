using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private InventoryItem cellPref;
    public ListItems listItems;
    public GameObject panel;
    public Image image;

    private void Awake()
    {
        SceneEventManager.OnPickItem += SomethingPick;
        SceneEventManager.OnCheckedItemInInventory += CheckItemInInventory;
        Instance = this;
    }

    public static PlayerItems Instance;
    private List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void SomethingPick(ItemType item)
    {

        InventoryItem inventoryItem = Instantiate(cellPref, panel.transform);
        inventoryItem.SetImageOnItem(item);
        PlayerItems.Instance.AddItem(new Item(item));
    }

    public PlayerItems() { }

    private void OnDestroy()
    {
        SceneEventManager.OnPickItem -= SomethingPick;
    }

    public bool CheckItemInInventory(ItemType item) => items.Exists(x => x.name == item);
}



public class Item
{
    public ItemType name;

    public Item(ItemType name)
    {
        this.name = name;
    }
}
