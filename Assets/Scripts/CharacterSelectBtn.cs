using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectBtn : MonoBehaviour
{
    public UnityEvent characterClick;
    public GameObject KnightObject;
    public GameObject WizardObject;
    public GameObject ArcherObject;

    public GameObject KnightMagicSkills;
    public GameObject WizardMagicSkills;
    public GameObject ArcherMagicSkills;

    public Sprite btnUp;
    public Sprite btnDown;

    public Text characterName;
    public Text characterDescription;


    // Place the character name here, in case if user wants to go back to change their character
    // It will stay as a placeholder to show the last character they've chosen.
    public static string selectedCharacter = "";

    void awake()
    {
        if (characterClick == null)
            characterClick = new UnityEvent();
    }

    // Dionia Region
    // Start is called before the first frame update
    void Start()
    {
        if (WorldSelect.chosenCharacter == "Knight" || WorldSelect.chosenCharacter == "")
        {
            characterName.text = "Knight";
            characterDescription.text = "A noble knight with a strong sense of dignity and loyalty. Has a strong physical attack with decent magic power.";
            KnightObject.SetActive(true);
            WizardObject.SetActive(false);
            ArcherObject.SetActive(false);

            KnightMagicSkills.SetActive(true);
        }
        else if (WorldSelect.chosenCharacter == "Wizard")
        {
            characterName.text = "Wizard";
            characterDescription.text = "A noble wizard with a strong sense of dignity and loyalty. Has a strong magic attack with decent physical power.";
            KnightObject.SetActive(false);
            WizardObject.SetActive(true);
            ArcherObject.SetActive(false);

            WizardMagicSkills.SetActive(true);
        }
        else if (WorldSelect.chosenCharacter == "Archer")
        {
            characterName.text = "Archer";
            characterDescription.text = "A noble arcer with a strong sense of dignity and loyalty. Has a strong magic power with great long range attacks.";
            KnightObject.SetActive(false);
            WizardObject.SetActive(false);
            ArcherObject.SetActive(true);

            ArcherMagicSkills.SetActive(true);
        }





    }

    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = btnDown;
        Debug.Log(GetComponent<SpriteRenderer>().sprite.name);
    }

    // When you touch the New Game Button
    void OnMouseUp()
    {
        characterClick.Invoke();
        GetComponent<SpriteRenderer>().sprite = btnUp;
    }


    public void selectedKnight()
    {
        characterName.text = "Knight";
        characterDescription.text = "A noble knight with a strong sense of dignity and loyalty. Has a strong physical attack with decent magic power.";

        KnightObject.SetActive(true);
        WizardObject.SetActive(false);
        ArcherObject.SetActive(false);

        KnightMagicSkills.SetActive(true);
        WizardMagicSkills.SetActive(false);
        ArcherMagicSkills.SetActive(false);

        WorldSelect.chosenCharacter = characterName.text;

    }

    public void selectedWizard()
    {
        characterName.text = "Wizard";
        characterDescription.text = "A noble wizard with a strong sense of dignity and loyalty. Has a strong magic attack with decent physical power.";

        KnightObject.SetActive(false);
        WizardObject.SetActive(true);
        ArcherObject.SetActive(false);

        KnightMagicSkills.SetActive(false);
        WizardMagicSkills.SetActive(true);
        ArcherMagicSkills.SetActive(false);

        WorldSelect.chosenCharacter = characterName.text;
    }

    public void selectedArcher()
    {
        characterName.text = "Archer";
        characterDescription.text = "A noble arcer with a strong sense of dignity and loyalty. Has a strong magic power with great long range attacks.";

        KnightObject.SetActive(false);
        WizardObject.SetActive(false);
        ArcherObject.SetActive(true);

        KnightMagicSkills.SetActive(false);
        WizardMagicSkills.SetActive(false);
        ArcherMagicSkills.SetActive(true);

        WorldSelect.chosenCharacter = characterName.text;
    }



}
