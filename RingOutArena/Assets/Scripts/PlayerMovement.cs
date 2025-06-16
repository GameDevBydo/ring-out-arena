using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    Rigidbody rb;
    PlayerCombat pCombat;
    Vector3 InputKey;

    float MyFloat;   // Necessário para SmoothDampAngle, muda nada

    public float speed = 300, maxSpeed = 5;    // Valores defaults de movimentação. Damping em 15.

    [HideInInspector] public float hitStunTimer;
    [HideInInspector] public bool lockMovement = false;
    [HideInInspector] public int controllerID;
    [HideInInspector] public bool blocking;
    public float defenseScale = 0.5f;

    Vector2 moveStick = new Vector2();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pCombat = GetComponent<PlayerCombat>();
    }

    void Update()
    {
        //var gamepadLeftStick = Gamepad.all[controllerID].leftStick.ReadValue();
        InputKey = new Vector3(moveStick.x, 0, moveStick.y);

        if (Input.GetKeyDown(KeyCode.LeftShift)) // Dash
        {
            rb.AddForce(transform.forward * 10, ForceMode.Impulse);
        }

        //blocking = Input.GetKey(KeyCode.Mouse1);
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
            else rb.linearVelocity *= 1 - (Time.fixedDeltaTime * 10);
        }
        if (InputKey.magnitude >= 0.1f)
        {
            float angle = Mathf.Atan2(InputKey.x, InputKey.z) * Mathf.Rad2Deg;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref MyFloat, 0.1f);

            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        }

        rb.AddForce(Vector3.down * 50);
    }
    public void OnMove(InputValue value)
    {
        moveStick = value.Get<Vector2>();
    }

    public void OnBlock(InputValue button)
    {
        if (button.isPressed) blocking = true;
        if (!button.isPressed) blocking = false;
    }
    public void LockMovement()
    {
        lockMovement = true;
    }

    void UnlockMovement()
    {
        lockMovement = false;
    }

    public void TakeKnockback(Vector3 dir, float power)
    {
        if (blocking) power *= defenseScale;
        rb.linearVelocity = Vector3.zero;
        rb.AddForce(dir * power, ForceMode.Impulse);
        LockMovement();
        hitStunTimer = 0.3f;
    }

    public void RestartPosition()
    {
        rb.linearVelocity = Vector3.zero;
        transform.position = Vector3.up;
        LockMovement();
        hitStunTimer = 0.5f;
        pCombat.invulTime = 1f;
        pCombat.ShowHitbox(false);
    }
}
