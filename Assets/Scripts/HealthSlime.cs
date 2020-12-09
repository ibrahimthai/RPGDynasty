using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Health Bar for Slime */
public class HealthSlime : MonoBehaviour
{
    // Health bar
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }
    public Slider healthBar;

    // Hold key for each enemy 
    public static float damageKey = 0;

    // Explosion once the Slime dies
    public GameObject explosion;

    // Current health score
    public Text slimeCurrentscore;
       
    private void Start()
    {
        // Health starts and resets to full when starting game again
        // Change full health here
        MaxHealth = 40f;
        CurrentHealth = MaxHealth;
        healthBar.value = MaxHealth;
        slimeCurrentscore.text = healthBar.value.ToString();

    }

    private void Update()
    {
        // Damage numbers
        if (damageKey > 0)
        {
            // Key 1: Sword
            if (damageKey == 1)
                DealDamage(20);
            // Key 2: Arrow
            else if (damageKey == 2)
                DealDamage(5);
            // Key 3: Punch
            else if (damageKey == 3)
                DealDamage(5);

            // Resets the key after player hits an object again
            damageKey = 0;
        }

    }

    void DealDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
        healthBar.value = CurrentHealth;
        Debug.Log("Enemy health is " + healthBar.value);
        slimeCurrentscore.text = healthBar.value.ToString();

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Debug.Log("Enemy died");
            
            // Once Slime dies, destroy the object and explode it
            Destroy(this.gameObject);            
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);

            // Enter items that will drop here
            //ItemWorld.SpawnItemWorld(new Vector3(6, -1, 1), new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
            //ItemWorld.SpawnItemWorld(new Vector3(7, -1, 1), new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
            //ItemWorld.SpawnItemWorld(new Vector3(8, -1, 1), new Item { itemType = Item.ItemType.Katana, amount = 1 });
        }
    }


}
