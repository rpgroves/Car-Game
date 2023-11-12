using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationSpawnNode : MonoBehaviour
{
    bool hasDestination = false;
    bool isWaitingToBeAvailable;

    void Update()
    {
        
    }

    public void SpawnDestination(GameObject destinationPrefab)
    {
        Instantiate(destinationPrefab, gameObject.transform);
    }

    public void SetHasDestination(bool b)
    {
        hasDestination = b;
    }
    public bool GetHasDestination()
    {
        return hasDestination;
    }
}
