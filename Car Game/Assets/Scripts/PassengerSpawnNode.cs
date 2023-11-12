using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerSpawnNode : MonoBehaviour
{
    bool hasPassenger = false;
    bool isWaitingToBeAvailable;

    void Update()
    {
        
    }

    public void SpawnPassenger(GameObject passengerPrefab)
    {
        Instantiate(passengerPrefab, gameObject.transform);
    }

    public void SetHasPassenger(bool b)
    {
        hasPassenger = b;
    }
    public bool GetHasPassenger()
    {
        return hasPassenger;
    }
}
