using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2 : MonoBehaviour
{
    [Header("Car Settings")]
    public float moveSpeed = 3.0f;
    public float rotateSpeed = 3.0f;
    
    float moveSpeedMax;
    Vector2 rawInput;
    Vector2 rawRotation;
    bool isPlayerInControl = true;
    bool isThereGas = true;
    Rigidbody2D rigidBody;
    Player player;
    float gasTimer = 0.0f;

    void Start()
    {
        moveSpeedMax = moveSpeed;
        rigidBody = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        if(isPlayerInControl)
        {
            HandleMovement();
        }
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
    void OnTurn(InputValue value)
    {
        rawRotation = value.Get<Vector2>();
    }

    public void HandleMovement()
    {
        if(isPlayerInControl)
        {
            Vector3 deltaMove = rawInput * moveSpeed * Time.deltaTime;
            if(deltaMove.y != 0)
            {
                rigidBody.AddForce(transform.right * deltaMove.y);
                gasTimer += Time.deltaTime;
                if(gasTimer >= 1.0f)
                {
                    player.DecrementGas();
                    gasTimer = 0.0f;
                }
            }

            Vector3 deltaRotate = rawRotation * rotateSpeed * Time.deltaTime;
            if(deltaRotate.x != 0)
            {
                if(deltaRotate.x < 0)
                    rigidBody.AddTorque(rotateSpeed);
                else
                    rigidBody.AddTorque(-rotateSpeed);
            }

            rawInput.Normalize();
            rawRotation.Normalize();
        }
    }
    public void SetIsPlayerInControl(bool b)
    {
        isPlayerInControl = b;
    }
    public void SetIsThereGas(bool b)
    {
        isThereGas = b;
        if(isThereGas == false)
        {
            moveSpeed = moveSpeedMax / 3;
        }
        else
        {
            moveSpeed = moveSpeedMax;
        }
    }
}
