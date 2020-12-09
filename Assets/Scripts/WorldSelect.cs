using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldSelect : MonoBehaviour
{
    public UnityEvent stageClick;
    public GameObject CursorHouse;
    public GameObject CursorForest;
    public GameObject CursorVolcano;
    public GameObject CursorDesert;
    public GameObject CursorSnowfield;

    public Text biomeName;

    public static string chosenCharacter = "";

    void awake()
    {
        if (stageClick == null)
            stageClick = new UnityEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Start with House
        biomeName.text = "Your Home";
        SelectBiome(true, false, false, false, false);
    }

    void OnMouseDown()
    {
    }

    // When you touch the New Game Button
    void OnMouseUp()
    {
        stageClick.Invoke();
    }

    // Clicked House
    public void SelectHouse()
    {
        biomeName.text = "Your Home";
        SelectBiome(true, false, false, false, false);
    }

    // Clicked Forest
    public void SelectForest()
    {
        biomeName.text = "Strafmont Forest";
        SelectBiome(false, true, false, false, false);
    }

    // Clicked Volcano
    public void SelectVolcano()
    {
        biomeName.text = "Corona Volcano";
        SelectBiome(false, false, true, false, false);
    }

    // Clicked Desert
    public void SelectDesert()
    {
        biomeName.text = "Drionia Desert";
        SelectBiome(false, false, false, true, false);
    }

    // Clicked Snowfield
    public void SelectSnowfield()
    {
        biomeName.text = "Snowvale Fields";
        SelectBiome(false, false, false, false, true);
    }

    // Call this function to set whatever biome you choose
    private void SelectBiome(bool choseHouse, bool choseForest, bool choseVolcano, bool chosedesert, bool choseSnowfield)
    {
        CursorHouse.SetActive(choseHouse);
        CursorForest.SetActive(choseForest);
        CursorVolcano.SetActive(choseVolcano);
        CursorDesert.SetActive(chosedesert);
        CursorSnowfield.SetActive(choseSnowfield);
    }


}
