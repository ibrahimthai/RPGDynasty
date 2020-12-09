using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    // Add item sprites here
    public Sprite healthPotionSprite;
    public Sprite manaPotionSprite;
    public Sprite katanaSprite;
    public Sprite woodenSwordSprite;
    public Sprite battleAxeSprite;







}
