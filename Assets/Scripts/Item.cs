using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    // Input item names here
    public enum ItemType
    {
        HealthPotion,
        ManaPotion,
        Katana,
        WoodenSword,
        BattleAxe,
    }

    public ItemType itemType;
    public int amount;

    // Gets all the item sprites
    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.HealthPotion:     return ItemAssets.Instance.healthPotionSprite;
            case ItemType.ManaPotion:       return ItemAssets.Instance.manaPotionSprite;
            case ItemType.Katana:           return ItemAssets.Instance.katanaSprite;
            case ItemType.WoodenSword:      return ItemAssets.Instance.woodenSwordSprite;
            case ItemType.BattleAxe:        return ItemAssets.Instance.battleAxeSprite;

        }
    }

    public bool IsStackable()
    {
        switch(itemType)
        {
            default:
            case ItemType.HealthPotion:
            case ItemType.ManaPotion:
            case ItemType.Katana:
                return true;
            case ItemType.WoodenSword:
            case ItemType.BattleAxe:
                return false;
        }
    }






}
