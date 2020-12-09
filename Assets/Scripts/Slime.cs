using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Slime : MonoBehaviour
{
    private Animator anim;
    public float moveSpeed = 3.5f;
    float velX = 0f;
    float velY;
    Rigidbody2D rigbody;
    int turnBackFlag = -1;
    int xRotation = 180;

    // Use to enable and disable menu during battle
    public GameObject mainMenu;
    int enemyAttack = 0;


    // variable to hold a reference to our SpriteRenderer component
    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rigbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Running animation
    void Update()
    {
        velX = Player.enemyAttackFlag * turnBackFlag;
        velY = rigbody.velocity.y;
        rigbody.velocity = new Vector2(velX * moveSpeed, velY);

        // Start Slime Attack
        if (Player.enemyAttackFlag == 1)
        {
            enemyAttack = 1;
            anim.SetBool("SlimeIsRunning", true);
        }



    }

    // Collision Detection
    void OnCollisionEnter2D(Collision2D coll)
    {
        // Checks to make sure the animation is only played once
        // If the slime is attacking
        if (Player.enemyAttackFlag == 1)
        {
            // If it hits the player
            if (coll.gameObject.name == "Player")
            {
                anim.SetBool("AttackPlayer", true);
                StartCoroutine(MyCoroutineAttack());

                // Deplete Player Health
                HealthPlayer.playerDamageKey = 1;
            }

            // If it goes back to position
            if (coll.gameObject.name == "EnemyBackToPosition")
            {
                StartCoroutine(MyCoroutineGoBack());
                Player.enemyAttackFlag = 0;
                mainMenu.SetActive(true);
            }
        }

        // If the player is attacking
        else if (Player.enemyAttackFlag == 0)
        {
            anim.SetBool("SlimeIsRunning", false);
        }

        




    }

    IEnumerator MyCoroutineAttack()
    {
        // Enemy starts to attack
        if (enemyAttack == 1)
        {
            turnBackFlag = 0;
            anim.SetBool("AttackPlayer", true);

            // Now go back to your original position
            yield return new WaitForSeconds(1.0f);
            Flip();
            anim.SetBool("AttackPlayer", false);
            anim.SetBool("SlimeIsRunning", true);
            turnBackFlag = 1;
        }

        enemyAttack = 0;


    }

    // Slime goes back to the original position
    IEnumerator MyCoroutineGoBack()
    {
        turnBackFlag = -1;
        anim.SetBool("SlimeIsRunning", false);
        Flip();

        yield return new WaitForSeconds(0.5f);

    }

    // Flips the player
    void Flip()
    {
        transform.Rotate(new Vector3(0, xRotation, 0));
    }





}
