using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;
using System.Diagnostics;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    public GameObject inventoryMenu;
    
    private void Awake() 
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
        inventoryMenu.SetActive(false);
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }


        // Location of where to start the item inventory
        int x = -1;
        int y = 1;

        // How far each slot will be together
        float itemSlotCellSize = 165f;

        foreach (Item item in inventory.GetItemList())
        {
            // Add new item to Inventory
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize+45, y * itemSlotCellSize-40);
            Image image = itemSlotRectTransform.Find("ItemImage").GetComponent<Image>();
            image.sprite = item.GetSprite();

            //UnityEngine.Debug.Log(item.itemType);

            // Use inventory
            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
            {
                // Use item
                //inventory.UseItem(item);
                UnityEngine.Debug.Log("Inventory");
            };

            




            

            TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1)
            {
                uiText.SetText(item.amount.ToString());
            }
            else
            {
                uiText.SetText("");
            }

            // Increment to add new box
            x++;

            // If the first row is over 6, create new row and fill it up
            if (x > 6)
            {
                x = -1;
                y--;
            }

        }
    }










}
