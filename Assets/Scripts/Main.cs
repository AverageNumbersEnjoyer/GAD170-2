using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    //Reference
    public Greenhouse greenhouse;
    public Plant plant;
    public GameObject plantPrefab;
    public GameObject newPlant;
    public GameObject canvas;
    //Initialise Variables
    int turnCount = 1;

    //Debug Instructions
    private void Start()
    {
        //greenhouse.plantsOwned.Clear();
        Debug.Log("You have 20 turns to have the most valuable Greenhouse");
        Debug.Log("Every turn 1 plant is presented to you");
        Debug.Log("Press the Keep or Pass button to make your choice");
        Debug.Log("Your Greenhouse has a max capacity of 10 plants");
        Debug.Log("Once you reach that limit, choosing to Keep a New Plant\nresults in the loss of the lowest quality Plant in the Greenhouse");
        SpawnPlant();
    }

    public void nextTurn()
    {
        if (turnCount < 21)
        {
            turnCount++;
            SpawnPlant();
        }
        else
        {
            canvas.SetActive(false);
        }
    }

    public void SpawnPlant()
    {
        if (newPlant != null)
        {
            newPlant.transform.position = new Vector3(0, -100, -10);
        }
        newPlant = Instantiate(plantPrefab);
    }

    public void ChooseKeep()
    {
        greenhouse.AddToGreenhouse(newPlant);
    }
}
