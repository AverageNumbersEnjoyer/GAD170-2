using System;
using System.Collections.Generic;
using UnityEngine;

public class SpeciesData : MonoBehaviour
{
    //Initialise Species Variables
    public string[] speciesList = new string[4] {"Rose", "Tulip", "Dandelions", "Orchid" };
    public int[] speciesValue = new int[4] { 15, 10, 5, 20 };

    public List<Material> materials;
}
