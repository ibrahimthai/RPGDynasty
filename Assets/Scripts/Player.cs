using System.Collections;
using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator anim;
    public float moveSpeed = 3.5f;
    float velX = 0f;
    float velY;
    Rigidbody2D rigbody;
    int turnBackFlag = 1;
    int xRotation = 180;

    public static int enemyAttackFlag = 0;
    public static int enemyFinishedAttackFlag = 0;

    // variable to hold a reference to our SpriteRenderer component
    private SpriteRenderer mySpriteRenderer;

    // Inventory
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;
    public Collider2D collider;

    // Heal Effect
    public GameObject healEffect;

    // Use to enable and disable menu during battle
    public GameObject mainMenu;
    public GameObject UIMagicMenu;
    public GameObject UIInventoryMenu;

    public static string imageObject;
    public static string imageName;
    public GameObject UseButton;

    public Image item;
    public Text itemDescription;
    public Sprite[] spriteArray; 


    // Start is called before the first frame update
    void Start()
    {
        rigbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        inventory = new Inventory(UseItem);
        uiInventory.SetInventory(inventory);
        UseButton.SetActive(false);
}

    // Running animation
    void Update()
    {
        velX = AttackButton.commandFlag * turnBackFlag;
        velY = rigbody.velocity.y;
        rigbody.velocity = new Vector2(velX * moveSpeed, velY);

        // Start Sword Attack
        if (AttackButton.commandFlag == 1)
        {
            if (AttackButton.commandString == "Attack")
                PlayerAttackTypes.attackType = 1;

            anim.SetBool("PlayerIsRunning", true);
        }

        // Interactive Inventory System: When user clicks an item in the Inventory
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            
            if (hit)
            {
                // If you clicked an Inventory slot
                if (hit.collider.gameObject.name == "ItemSlotTemplate(Clone)")
                {
                    // Loop through children of GameObject
                    for (int i = 0; i < hit.collider.gameObject.transform.childCount - 1; i++)
                    {
                        imageObject = hit.collider.gameObject.transform.GetChild(i).transform.name;

                        // Check if you found an Image Object
                        if (imageObject == "ItemImage")
                        {
                            Image image = hit.collider.gameObject.transform.GetChild(i).GetComponent<Image>();
                            imageName = image.sprite.name;
                            Debug.Log(imageName);

                            // Once player clicks an item, set Use Button active
                            UseButton.SetActive(true);

                            UpdateItemDescription(imageName);

                            
                        }

                    }

                }
            }
        }

        // Use Button: Use item
        if (UseItemButton.itemClicked == true)
        {
            Debug.Log(imageName);
            UseItemButton.itemClicked = false;

            // Health Potion
            if (imageName == "Items_130")
            {
                // Initiate Heal Effect
                GameObject e = Instantiate(healEffect) as GameObject;
                e.transform.position = new Vector3(transform.position.x, transform.position.y, 1);

                // Remove the Health Potion in Inventory
                Item healthPotion = new Item { itemType = Item.ItemType.HealthPotion, amount = 1 };
                UseItem(healthPotion);

                UIMagicMenu.SetActive(false);
                UIInventoryMenu.SetActive(false);
                mainMenu.SetActive(false);

                StartCoroutine(MyCoroutineUsedItem());

                // Reset the string, if user wants to use another item
                imageObject = string.Empty;
                imageName = string.Empty;
            }
            else if (imageName == "Items_131")
            {
                
            }



        }



    }

    // Collision Detection
    void OnCollisionEnter2D(Collision2D coll)
    {
        // If the enemy is attacking
        if (enemyAttackFlag == 0)
        {
            // If it hits an enemy
            if (coll.gameObject.name == "Slime")
            {
                // Damage enemy by: 20 HP
                HealthSlime.damageKey = 1;
                anim.SetBool("SlashEnemy", true);
                StartCoroutine(MyCoroutineAttack());

                // Damage Key for Sword: 1
                HealthSlime.damageKey = 1;

            }

            // If it goes back to position
            if (coll.gameObject.name == "BackToPosition")
            {
                StartCoroutine(MyCoroutineGoBack());
                enemyAttackFlag = 1;
            }
        }

        else if (enemyAttackFlag == 1)
        {
            anim.SetBool("PlayerIsRunning", false);
        }



    }

    IEnumerator MyCoroutineAttack()
    {
        // Sword
        if (PlayerAttackTypes.attackType == 1)
        {
            turnBackFlag = 0;
            anim.SetBool("SlashEnemy", true);

            // Now go back to your original position
            yield return new WaitForSeconds(1.0f);
            //Flip();
            anim.SetBool("SlashEnemy", false);
            anim.SetBool("PlayerIsRunning", true);
            turnBackFlag = -1;
        }

        PlayerAttackTypes.attackType = 0;


    }

    // Player goes back to the original position
    IEnumerator MyCoroutineGoBack()
    {
        turnBackFlag = 1;
        anim.SetBool("PlayerIsRunning", false);
        //Flip();
        AttackButton.commandFlag = 0;
        AttackButton.commandString = "";
        yield return new WaitForSeconds(0.5f);

    }

    // Player goes back to the original position
    IEnumerator MyCoroutineUsedItem()
    {
        yield return new WaitForSeconds(2.0f);
        // Enemy attack once you use an item
        enemyAttackFlag = 1;
        
    }

    // Flips the player
    void Flip()
    {
        transform.Rotate(new Vector3(0, xRotation, 0));
    }


    private void UseItem(Item item)
    {
        switch(item.itemType)
        {
            case Item.ItemType.HealthPotion:
                Debug.Log("You used a Health Potion");
                inventory.RemoveItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
                break;
            case Item.ItemType.ManaPotion:
                Debug.Log("You used a Mana Potion");
                //inventory.RemoveItem(new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
                break;
        }
    }

    // Updates Item Description in Inventory Menu
    private void UpdateItemDescription(string itemName)
    {
        if (imageName == "Items_130")
        {
            item.sprite = spriteArray[0];
            itemDescription.text = "Restores +20 HP";
        }    
        else if (imageName == "Items_131")
        {
            item.sprite = spriteArray[1];
            itemDescription.text = "Restores +20 MP";
        }
            
    }

}
