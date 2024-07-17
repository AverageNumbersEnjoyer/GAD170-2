using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greenhouse : MonoBehaviour
{
    //Greenhosue Storage
    public List<GameObject> plantsOwned = new List<GameObject>();


    //Checks Greenhouse if it has max capacity of Plants
    public bool IsFull()
    {
        if (plantsOwned.Count >= 10)
        {
            return true;
        }
        return false;
    }

    //Removes Lowest Health Plant from Greenhouse List and Destroys it
    public void RemoveLowest()
    {
        //Initialise Starting point
        GameObject _lowestGO = plantsOwned[0];
        Plant _lowestP = _lowestGO.GetComponent<Plant>();
        int _lowestPosition = 0;

        //Iterate through plants in greenhouse to find the one with the lowest health
        for (int _i = 1; _i < plantsOwned.Count - 1; _i++)
        {
            GameObject _nextGO = plantsOwned[_i];
            if (_nextGO != null)
            {
                Plant _nextP = _nextGO.GetComponent<Plant>();

                //Two checks
                //1) If health is equal, check which has the lower Plant Value
                //2) If _next has less health, make it the new _lowest
            
                if (_lowestP.plantHealth == _nextP.plantHealth && _lowestP.plantValue > _nextP.plantValue ||
                    _lowestP.plantHealth > _nextP.plantHealth)
                {
                    _lowestGO = _nextGO;
                    _lowestP = _nextP;
                    _lowestPosition = _i;
                }
            }
        }

        //After looping through all Owned plants, remove the lowest health plant
        //Removes plant from list
        plantsOwned.RemoveAt(_lowestPosition);
        //Destroys Instance
        _lowestP.DestroyPlant();
    }

    public void AddToGreenhouse(GameObject _newPlant)
    {
        //If Greenhouse full, find lowest health plant and remove it
        if (IsFull())
        {
            RemoveLowest();
        }
        //Add Plant to list
        plantsOwned.Add(_newPlant);
      
        //Debug.Log(plantsOwned.Count);
    }

    //Sums all of the plant sale values and returns that sum
    public double CalculateTotalValue()
    {
        //Initialise value to return
        double _totalValue = 0;
        //Loop through list, adding each plant value to return value
        for (int _i = 0; _i < plantsOwned.Count - 1; _i++)
        {
            Plant _plant = plantsOwned[_i].GetComponent<Plant>();

            _totalValue += _plant.plantValue;
            
        }
        //Return sum
        return _totalValue;
    }
}
