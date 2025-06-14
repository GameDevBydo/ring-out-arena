using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    Rigidbody rb;
    Vector3 InputKey;

    float MyFloat;   // Necessário para SmoothDampAngle, muda nada

    public float speed = 300, maxSpeed = 5;    // Valores defaults de movimentação. Damping em 15.

    [HideInInspector] public float hitStunTimer;
    [HideInInspector] public bool lockMovement = false;
    bool blocking;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var gamepadLeftStick = Gamepad.all[0].leftStick.ReadValue();
        InputKey = new Vector3(gamepadLeftStick.x, 0, gamepadLeftStick.y);

        if (Input.GetKeyDown(KeyCode.Q)) // Transformar isso em uma função do atacante
        {
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(Vector3.left * 15, ForceMode.Impulse);
            LockMovement();
            hitStunTimer = 0.3f;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) // Dash
        {
            rb.AddForce(transform.forward * 10, ForceMode.Impulse);
        }

        blocking = Input.GetKey(KeyCode.Mouse1);
    }

    void FixedUpdate()
    {
        if (hitStunTimer > 0) hitStunTimer -= Time.fixedDeltaTime;
        else if (lockMovement) UnlockMovement();

        if (!lockMovement)
        {
            if (InputKey.magnitude > 0f && !blocking)
            {
                rb.AddForce(InputKey.normalized * speed);
                if (rb.linearVelocity.magnitude >= maxSpeed) rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
            else rb.linearVelocity *= 1 - (Time.fixedDeltaTime*10);
        }
        if (InputKey.magnitude >= 0.1f)
        {
            float angle = Mathf.Atan2(InputKey.x, InputKey.z) * Mathf.Rad2Deg;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref MyFloat, 0.1f);

            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        }
    }

    public void LockMovement()
    {
        lockMovement = true;
    }

    void UnlockMovement()
    {
        lockMovement = false;
    }
}
