using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UseItemButton : MonoBehaviour
{
    public UnityEvent buttonClick;
    public Sprite btnUp;
    public Sprite btnDown;
    public static bool itemClicked = false;
    
    void Awake()
    {
        if (buttonClick == null)
            buttonClick = new UnityEvent();
    }

    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = btnDown;
        Debug.Log(GetComponent<SpriteRenderer>().sprite.name);
    }

    // When you use an item
    void OnMouseUp()
    {
        buttonClick.Invoke();
        GetComponent<SpriteRenderer>().sprite = btnUp;
    }

    public void ClickItem()
    {
        itemClicked = true;
    }
}
