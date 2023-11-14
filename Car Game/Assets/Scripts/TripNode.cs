using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripNode : MonoBehaviour
{
    bool isOccupied = false;
    public bool GetIsOccupied()
    {
        return isOccupied;
    }
    public void SetIsOccupied(bool b)
    {
        isOccupied = b;
    } 
}
