using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Car Settings")]
    public float driftFactor = 0.05f;
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;
    public float maxSpeed = 3.5f;
    public Player player;

    //local variables
    float accelerationInput = 0.0f;
    float steeringInput = 0.0f;
    float rotationAngle = 0.0f;
    float velocityVsUp = 0.0f;
    bool isThereGas = true;
    Rigidbody2D rigidbody;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        ApplyEngineForce();
        KillOrthogonalVelocity();
        ApplySteering();
    }
    void ApplyEngineForce()
    {
        if(accelerationInput != 0)
            player.DecrementGas();
        float multi = 1.0f;
        if(!isThereGas)
            multi = 0.5f;

        velocityVsUp = Vector2.Dot(transform.up, rigidbody.velocity);
        if(velocityVsUp > maxSpeed * multi && accelerationInput > 0)
            return;
        if(velocityVsUp < -maxSpeed * multi * 0.5f && accelerationInput < 0)
            return;
        if(rigidbody.velocity.sqrMagnitude > maxSpeed * maxSpeed * multi * multi && accelerationInput > 0)
            return;

        if(accelerationInput == 0)
            rigidbody.drag = Mathf.Lerp(rigidbody.drag, 3.0f, Time.fixedDeltaTime * 3);
        else
            rigidbody.drag = 0;

        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;
        
        rigidbody.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        float minSpeedBeforeAllowTurningFactor = (rigidbody.velocity.magnitude / 8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;
        rigidbody.MoveRotation(rotationAngle);
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

    public bool GetIsThereGas()
    {
        return isThereGas;
    }

    public void SetIsThereGas(bool b)
    {
        isThereGas = b;
    }

    void OnMove(InputValue value)
    {
        Vector2 rawInput = value.Get<Vector2>();
        SetInputVector(rawInput);
    }

    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rigidbody.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rigidbody.velocity, transform.right);

        rigidbody.velocity = forwardVelocity + rightVelocity * driftFactor;
    }
}
