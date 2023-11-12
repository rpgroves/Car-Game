using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    float payment = 10.0f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Dropoff(Player player)
    {
        Debug.Log("dropoff!");
        player.AddMoney(payment);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
