using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        //When plant created, set their stats and log to console
        RandomisePlant();
        DebugNewPlant();
    }

    //Log Stats to Debug Console
    void DebugNewPlant()
    {
        Debug.Log("New Plant| Species: " + species + " Health: " + plantHealth.ToString() + " Value: $" + plantValue.ToString());
    }

    void RandomisePlant()
    {
        //Initialise Plant variable values
        plantHealth = Random.Range(1, 11);
        //Random number for Species 
        var _rNum = Random.Range(0, 4);
        species = speciesData.speciesList[_rNum];
        speciesValue = speciesData.speciesValue[_rNum];
        //Calculate Plant Value
        plantValue = (double)(plantHealth + 1) / 5d * (double)speciesValue;

        //Using SpeciesData, give Flowers their unique colour
        material = speciesData.materials[_rNum];
        Renderer _renderer = GetComponent<Renderer>();
        _renderer.material = material;
    }

    public void DestroyPlant()
    {
        Destroy(gameObject);
    }

    
}
