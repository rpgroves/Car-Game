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
    bool isYellow = false;
    [SerializeField] float timeBetweenLights = 10.0f;
    [SerializeField] float timeForYellow = 4.0f;
    float currentGreenTime = 3.0f;
    float currentYellowTime = 3.0f;
    void Start()
    {
        northLight.color = Color.green;
        southLight.color = Color.green;
        eastLight.color = Color.red;
        westLight.color = Color.red;
        isNorthSouthGreen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isYellow)
        {
            currentGreenTime += Time.deltaTime;
            if(currentGreenTime > timeBetweenLights)
            {
                SwapToYellow();
                currentGreenTime = 0.0f;
                currentYellowTime = 0.0f;
            }
        }
        if(isYellow)
        {
            currentYellowTime += Time.deltaTime;
            if(currentYellowTime > timeBetweenLights)
            {
                SwapLights();
                currentGreenTime = 0.0f;
                currentYellowTime = 0.0f;
            }
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
            isYellow = false;
        }
        else
        {
            northLight.color = Color.green;
            southLight.color = Color.green;
            eastLight.color = Color.red;
            westLight.color = Color.red;
            isNorthSouthGreen = true;
            isYellow = false;
        }
    }

    void SwapToYellow()
    {
        if(!isNorthSouthGreen)
        {
            northLight.color = Color.red;
            southLight.color = Color.red;
            eastLight.color = Color.yellow;
            westLight.color = Color.yellow;
            isYellow = true;
        }
        else
        {
            northLight.color = Color.yellow;
            southLight.color = Color.yellow;
            eastLight.color = Color.red;
            westLight.color = Color.red;
            isYellow = true;
        }
    }

    public bool GetIsNorthSouthGreen()
    {
        return isNorthSouthGreen;
    }
    public bool GetIsYellow()
    {
        return isYellow;
    }
}
