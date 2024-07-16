using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Plant : MonoBehaviour
{
    //Get Species Data Script
    public SpeciesData speciesData;
    //Initialise Plant Variables
    public string species;
    public int speciesValue;
    public int plantHealth;
    public double plantValue;

    public Material material;
    public TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        createPlant();
        DebugNewPlant();
    }


    void DebugNewPlant()
    {
        Debug.Log("New Plant| Species: " + species + " Health: " + plantHealth.ToString() + " Value: $" + plantValue.ToString());
    }

    void createPlant()
    {
        //Initialise Plant variable values
        plantHealth = Random.Range(1, 11);
        //Random number for Species 
        var _rNum = Random.Range(0, 4);
        species = speciesData.speciesList[_rNum];
        speciesValue = speciesData.speciesValue[_rNum];
        //Calculate Plant Value
        plantValue = (double)(plantHealth + 1) / 5 * speciesValue;

        material = speciesData.materials[_rNum];
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = material;

        tmp.text = ("Species: " + species);
    }


    
}
