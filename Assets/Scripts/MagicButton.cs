using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MagicButton : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject magicMenu;
    public UnityEvent buttonClick;
    public Sprite btnUp;
    public Sprite btnDown;

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

    // Click Magic Button
    public void selectedMagicMenu()
    {
        mainMenu.SetActive(false);
        magicMenu.SetActive(true);
    }

    // Click Go Back Button
    public void GoBackMainMenu()
    {
        mainMenu.SetActive(true);
        magicMenu.SetActive(false);
    }
}
