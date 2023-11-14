using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    [SerializeField] Destination destination;

    public Destination Pickup()
    {
        destination.gameObject.SetActive(true);
        return destination;
    }
}
