using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BattlefieldCommands : MonoBehaviour
{
    public UnityEvent buttonClick;
    public Sprite btnUp;
    public Sprite btnDown;
    public GameObject AttackMenu;
    public GameObject BattleMenu;
    public GameObject StatsMenu;
    public static string commandName;

    public static int swordFlag = 0;

    void Awake()
    {
        if (buttonClick == null)
            buttonClick = new UnityEvent();
    }

    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = btnDown;
        //Debug.Log(GetComponent<SpriteRenderer>().sprite.name);
        commandName = GetComponent<SpriteRenderer>().sprite.name;
    }

    // When you touch the New Game Button
    void OnMouseUp()
    {
        buttonClick.Invoke();
        GetComponent<SpriteRenderer>().sprite = btnUp;
    }

    // If user presses "Quit" during battle
    public void QuitBattle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    // If user clicks "Attack": Battle Menu -> Attack Menu
    public void DisplayAttackMenu()
    {
        AttackMenu.SetActive(true);
        BattleMenu.SetActive(false);
        StatsMenu.SetActive(false);
    }

    // If user clicks "Back" Arrow: Attack Menu -> Battle Menu
    public void DisplayBattleMenu()
    {
        AttackMenu.SetActive(false);
        BattleMenu.SetActive(true);
        StatsMenu.SetActive(false);
    }

    // If user clicks "Back" Arrow: Attack Menu -> Battle Menu
    public void DisplayStatsMenu()
    {
        AttackMenu.SetActive(false);
        BattleMenu.SetActive(false);
        StatsMenu.SetActive(true);
    }

    // If user clicks "Back" Arrow: Attack Menu -> Battle Menu
    public void QuitStatsMenu()
    {
        AttackMenu.SetActive(false);
        BattleMenu.SetActive(true);
        StatsMenu.SetActive(false);
    }






}
