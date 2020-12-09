using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class AttackButton : MonoBehaviour
{
    public GameObject mainMenu;
    public UnityEvent buttonClick;
    public Sprite btnUp;
    public Sprite btnDown;

    public static int commandFlag = 0;
    public static string commandString = "";

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

    // Slash Attack
    public void selectedAttack()
    {
        mainMenu.SetActive(false);
        commandFlag = 1;
        commandString = "Attack";
    }
}
