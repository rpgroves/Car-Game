using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCar : MonoBehaviour
{
    [SerializeField] int direction = 1; //1 = northSpawn, 2 = southSpawn, 3 = eastSpawn, 4 = westSpawn
    [SerializeField] float moveSpeed = 3.0f;
    bool hasPassedExtraZone = false;
    bool hasObstacleAhead = false;
    bool hasTrafficLightAhead = false;
    Rigidbody2D rigidBody;
    TrafficLight trafficLight;
    [SerializeField] float waitTime = 0.5f;
    float timer = 0.5f;
    bool isWaiting = false;
    bool isStoppedAtLight = false;
    

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(isWaiting)
            timer += Time.deltaTime;
        if(timer > waitTime)
            isWaiting = false;
        if(!isWaiting)
            HandleMovement();
    }

    public void HandleMovement()
    {
        if(hasTrafficLightAhead)
        {
            if(trafficLight.GetIsYellow())
            {
                hasObstacleAhead = true;
                return;
            }
            bool isNorthSouthGreen = trafficLight.GetIsNorthSouthGreen();
            if((direction == 1 || direction == 2) && isNorthSouthGreen)
            {
                hasTrafficLightAhead = false;
                hasObstacleAhead = false;
                if(isStoppedAtLight)
                {
                    isWaiting = true;
                    timer = 0.0f;
                }
                return;
            }
            else if((direction == 3 || direction == 4) && !isNorthSouthGreen)
            {
                hasTrafficLightAhead = false;
                hasObstacleAhead = false;
                if(isStoppedAtLight)
                {
                    isWaiting = true;
                    timer = 0.0f;
                }
                return;
            }
            else
            {
                isStoppedAtLight = true;
                return;
            }
        }
        if(hasObstacleAhead)
        {
            return;
        }
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
        {
            if(direction == 1)
            {
                if(other.gameObject.transform.position.y > gameObject.transform.position.y)
                {
                    return;
                }
            }
            if(direction == 2)
            {
                if(other.gameObject.transform.position.y < gameObject.transform.position.y)
                {
                    return;
                }
            }
            if(direction == 3)
            {
                if(other.gameObject.transform.position.x > gameObject.transform.position.x)
                {
                    return;
                }
            }
            if(direction == 4)
            {
                if(other.gameObject.transform.position.x < gameObject.transform.position.x)
                {
                    return;
                }
            }
            hasObstacleAhead = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        hasObstacleAhead = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("ouch!");
        if(other.gameObject.tag == "NPC" || other.gameObject.tag == "Bounds")
        {
            Destroy(this.gameObject);
        }
    }
}
