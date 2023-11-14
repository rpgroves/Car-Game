using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    [SerializeField] float payment = 10.0f;

    public void Dropoff(Player player)
    {
        player.AddMoney(payment);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
