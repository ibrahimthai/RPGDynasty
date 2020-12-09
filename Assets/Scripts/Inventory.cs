using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;
    private List<Item> itemList;
    private Action<Item> useItemAction;

    public Inventory(Action<Item> useItemAction)
    {
        this.useItemAction = useItemAction;
        itemList = new List<Item>();
        //Debug.Log("Inventory");

        
        AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 3 });
        AddItem(new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.Katana, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.WoodenSword, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.BattleAxe, amount = 1 });
        


        //Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        if(item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                itemList.Add(item);
            }
            
        }
        else
        {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                itemList.Remove(itemInInventory);
            }

        }
        else
        {
            itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }


    public void UseItem(Item item)
    {
        Debug.Log("You clicked an Inventory Item");
        useItemAction(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }


}
