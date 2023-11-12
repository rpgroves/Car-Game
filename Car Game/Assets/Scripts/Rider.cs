using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rider : MonoBehaviour
{
    [SerializeField] Destination destination;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public Destination Pickup()
    {
        destination.gameObject.SetActive(true);
        Debug.Log("Passenger here!");
        return destination;
    }
}
