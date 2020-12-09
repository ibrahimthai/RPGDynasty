using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Health bar for player */
public class HealthPlayer : MonoBehaviour
{
    // Health bar
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }
    public Slider healthBar;

    // Current health score
    public Text myCurrentscore;


    // Hold key for player 
    public static float playerDamageKey = 0;

    private void Start()
    {
        // Health starts and resets to full when starting game again
        // Change full health here
        MaxHealth = 80f;
        CurrentHealth = MaxHealth;
        healthBar.value = MaxHealth;
        myCurrentscore.text = healthBar.value.ToString();
    }

    private void Update()
    {
        // Damage numbers
        if (playerDamageKey > 0)
        {
            // Key 1: Slime Attack
            if (playerDamageKey == 1)
                DealDamage(20);
            // Key 2: Arrow
            else if (playerDamageKey == 2)
                DealDamage(5);
            // Key 3: Punch
            else if (playerDamageKey == 3)
                DealDamage(5);

            // Resets the key after player hits an object again
            playerDamageKey = 0;
        }

    }

    void DealDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
        healthBar.value = CurrentHealth;
        Debug.Log("Player health is " + healthBar.value);
        myCurrentscore.text = healthBar.value.ToString();

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Debug.Log("Player died");
            Time.timeScale = 0;
        }
    }


}
