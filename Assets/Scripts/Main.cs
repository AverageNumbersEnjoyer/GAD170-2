using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Main : MonoBehaviour
{
    //Reference
    public Greenhouse greenhouse;
    public Plant plant;
    public GameObject plantPrefab;
    public GameObject infoCanvas;
    public GameObject endScreenCanvas;
    public TextMeshProUGUI tmpInfo;
    public TextMeshProUGUI tmpEndScreen;
    //Initialise Variables
    int turnCount = 1;
    public GameObject newPlant;
    public Plant newPlantProp;
    private Coroutine delayedcoroutine;

    //Debug Instructions
    private void Start()
    {
        endScreenCanvas.SetActive(false);
        Debug.Log("You have 20 turns to have the most valuable Greenhouse");
        Debug.Log("Every turn 1 plant is presented to you");
        Debug.Log("Press the Keep or Pass button to make your choice");
        Debug.Log("Your Greenhouse has a max capacity of 10 plants");
        Debug.Log("Once you reach that limit, choosing to Keep a New Plant\nresults in the loss of the lowest quality Plant in the Greenhouse");

        tmpInfo = infoCanvas.GetComponentInChildren<TextMeshProUGUI>();
        //Manually Spawns firsts plant and updates UI accordingly
        SpawnPlant();
    }

    //If game not ended yet, increment turn count and bring in next plant
    //If game ends, turn off new plant canvas
    public void NextTurn()
    {
        if (turnCount < 21)
        {
            turnCount++;
            SpawnPlant();
        }
        else
        {
            infoCanvas.SetActive(false);
            endScreenCanvas.SetActive(true);
            UpdateEndScreen();
        }
    }

    public void SpawnPlant()
    {
        if (newPlant != null)
        {
            newPlant.transform.position = new Vector3(0, -100, -10);
        }
        newPlant = Instantiate(plantPrefab);


        

        if (delayedcoroutine == null)
        {   
            delayedcoroutine = StartCoroutine(UpdateUI());
        }
    }

    IEnumerator UpdateUI()
    {
        yield return new WaitForSecondsRealtime(0.10f);

        newPlant.transform.parent = transform;
        newPlantProp = newPlant.GetComponentInParent<Plant>();
        //Debug.Log(newPlantProp.species);
        tmpInfo.text = "Species: " + newPlantProp.species + "\nQuality: " + newPlantProp.plantHealth + "/10 \nEstimated Value: $" + newPlantProp.plantValue;
        
        delayedcoroutine = null;
    }

    //For UI Button Keep, add's plant to greenhouse and removes lowest HP is greenhouse full, starts next turn
    public void ChooseKeep()
    {
        greenhouse.AddToGreenhouse(newPlant);
        NextTurn();

    }

    //For UI Button Pass, destroys new plant, start next turn
    public void ChoosePass()
    {
        Destroy(newPlant);
        NextTurn();
        
    }

    public void UpdateEndScreen()
    {
        tmpEndScreen.text = "Greenhouse Value : $" + greenhouse.CalculateTotalValue().ToString() + "0";
    }
}
