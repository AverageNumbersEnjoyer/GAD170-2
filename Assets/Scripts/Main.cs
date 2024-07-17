using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Main : MonoBehaviour
{
    //References
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

    
    private void Start()
    {
		//Have the end screen inactive
        endScreenCanvas.SetActive(false);
		//Debug Instructions
        Debug.Log("You have 20 turns to have the most valuable Greenhouse");
        Debug.Log("Every turn 1 plant is presented to you");
        Debug.Log("Press the Keep or Pass button to make your choice");
        Debug.Log("Your Greenhouse has a max capacity of 10 plants");
        Debug.Log("Once you reach that limit, choosing to Keep a New Plant\nresults in the loss of the lowest quality Plant in the Greenhouse");

        tmpInfo = infoCanvas.GetComponentInChildren<TextMeshProUGUI>();
        //Send to Console what day it is
        Debug.Log("Day : " + turnCount);
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
            //Send to Console what day it is
            Debug.Log("Day : " + turnCount);
            SpawnPlant();
        }
		//Once turn 21 is reached, the game ends
        else
        {
			//New Plant info Canvas is inactive
			//End Screen Canvas is activated with final score
            infoCanvas.SetActive(false);
            endScreenCanvas.SetActive(true);
            UpdateEndScreen();
        }
    }

	//Instantiates a new plant, while moving the previous one off screen
	//Also Updates UI with new plant's info
    public void SpawnPlant()
    {
		//If game object exists, move it off screen
        if (newPlant != null)
        {
            newPlant.transform.position = new Vector3(0, -100, -10);
        }
		//Create new plant and set to variable
        newPlant = Instantiate(plantPrefab);        

		//If the Coroutine is not running, start it
        if (delayedcoroutine == null)
        {   
            delayedcoroutine = StartCoroutine(UpdateUI());
        }
    }

	//Coroutine to Update UI
    IEnumerator UpdateUI()
    {
		//Add a delay of 0.1 seconds
        yield return new WaitForSecondsRealtime(0.10f);

		//Child the newplant to the controller and get the script component off the game object
        newPlant.transform.parent = transform;
        newPlantProp = newPlant.GetComponentInParent<Plant>();
        //Debug.Log(newPlantProp.species);
        tmpInfo.text = "Species: " + newPlantProp.species + "\nQuality: " + newPlantProp.plantHealth + "/10 \nEstimated Value: $" + newPlantProp.plantValue;
        
		//Reset Coroutine Variable so it can be run again when called
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

	//Update the Text on the End Screen Canvas
    public void UpdateEndScreen()
    {
        tmpEndScreen.text = "Greenhouse Value : $" + greenhouse.CalculateTotalValue().ToString();
    }
}
