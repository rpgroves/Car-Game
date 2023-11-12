using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    [SerializeField] SpriteRenderer northLight;
    [SerializeField] SpriteRenderer southLight;
    [SerializeField] SpriteRenderer eastLight;
    [SerializeField] SpriteRenderer westLight;
    bool isNorthSouthGreen = false;
    [SerializeField] float timeBetweenLights = 10.0f;
    float currentTime = 3.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > timeBetweenLights)
        {
            SwapLights();
            currentTime = 0.0f;
        }
        
    }

    void SwapLights()
    {
        if(isNorthSouthGreen)
        {
            northLight.color = Color.red;
            southLight.color = Color.red;
            eastLight.color = Color.green;
            westLight.color = Color.green;
            isNorthSouthGreen = false;
        }
        else
        {
            northLight.color = Color.green;
            southLight.color = Color.green;
            eastLight.color = Color.red;
            westLight.color = Color.red;
            isNorthSouthGreen = true;
        }
    }

    public bool GetIsNorthSouthGreen()
    {
        return isNorthSouthGreen;
    }
}
