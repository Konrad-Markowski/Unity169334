using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementInput;
    private float rotationInput;
    
    [Header("Ustawienia Ruchu")]
    public float speed = 15f;
    public float rotationSpeed = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementInput = movementVector.y;
        rotationInput = movementVector.x;
    }

    void OnJump(InputValue movementValue)
    {
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = transform.forward * movementInput * speed;
        rb.AddForce(moveDirection);

        float rotationAmount = rotationInput * rotationSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0, rotationAmount, 0);
        
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}