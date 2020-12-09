using System.Collections;
using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UpdateItem : MonoBehaviour
{
    public Sprite[] spriteArray;
    public Image item;

    public void UpdateItemDescription(string itemName)
    {
        if (itemName == "Items_130")
            item.sprite = spriteArray[0];
        else if (itemName == "Items_131")
            item.sprite = spriteArray[1];
    }



}
