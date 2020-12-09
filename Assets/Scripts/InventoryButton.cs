using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InventoryButton : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject inventoryMenu;
    public UnityEvent buttonClick;
    public Sprite btnUp;
    public Sprite btnDown;
    public GameObject useButton;

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

    // When you touch the New Game Button
    void OnMouseUp()
    {
        buttonClick.Invoke();
        GetComponent<SpriteRenderer>().sprite = btnUp;
    }

    // Click Inventory Button
    public void selectedInventoryMenu()
    {
        useButton.SetActive(false);
        mainMenu.SetActive(false);
        inventoryMenu.SetActive(true);
        
    }

    // Click Go Back Button
    public void GoBackMainMenu()
    {
        useButton.SetActive(false);
        mainMenu.SetActive(true);
        inventoryMenu.SetActive(false);
    }
}
