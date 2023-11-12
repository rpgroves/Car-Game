using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCar : MonoBehaviour
{
    [SerializeField] int direction = 1; //1 = north, 2 = south, 3 = east, 4 = west
    [SerializeField] float moveSpeed = 3.0f;
    bool hasPassedExtraZone = false;
    bool hasObstacleAhead = false;
    bool hasTrafficLightAhead = false;
    Rigidbody2D rigidBody;
    TrafficLight trafficLight;
    

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        HandleMovement();
    }

    public void HandleMovement()
    {
        if(hasTrafficLightAhead)
        {
            Debug.Log("checking for light to change");
            bool isNorthSouthGreen = trafficLight.GetIsNorthSouthGreen();
            Debug.Log(isNorthSouthGreen);
            if((direction == 1 || direction == 2) && isNorthSouthGreen)
            {
                Debug.Log("green!");
                hasTrafficLightAhead = false;
                hasObstacleAhead = false;
            }
            else if((direction == 3 || direction == 4) && !isNorthSouthGreen)
            {
                Debug.Log("green!");
                hasTrafficLightAhead = false;
                hasObstacleAhead = false;
            }
            else
            {
                return;
            }
        }
        if(hasObstacleAhead)
            return;
        Vector3 v = new Vector3(0.0f, 1.0f, 0.0f);
        Vector3 deltaMove = v * moveSpeed * Time.deltaTime;
        rigidBody.AddForce(transform.right * deltaMove.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "TrafficLight")
        {
            trafficLight = other.gameObject.GetComponent<TrafficLight>();
            hasTrafficLightAhead = true;
        }
        else
            hasObstacleAhead = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        hasObstacleAhead = false;
    }
}
