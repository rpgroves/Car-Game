using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCarScan : MonoBehaviour
{
    public NPCCar myCar;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bounds")
            return;
        if(other.gameObject.tag == "TrafficLight")
        {
            myCar.SetTrafficLight(other);
        }
        else
        {
            if(myCar.GetDirection() == 1)
            {
                if(other.gameObject.transform.position.y > gameObject.transform.position.y)
                {
                    return;
                }
            }
            if(myCar.GetDirection() == 2)
            {
                if(other.gameObject.transform.position.y < gameObject.transform.position.y)
                {
                    return;
                }
            }
            if(myCar.GetDirection() == 3)
            {
                if(other.gameObject.transform.position.x > gameObject.transform.position.x)
                {
                    return;
                }
            }
            if(myCar.GetDirection() == 4)
            {
                if(other.gameObject.transform.position.x < gameObject.transform.position.x)
                {
                    return;
                }
            }
            myCar.SetHasObstacleAhead(true);
        }
    }
}
