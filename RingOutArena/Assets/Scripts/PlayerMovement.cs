using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    Rigidbody rb;
    Vector3 InputKey;

    float MyFloat;   // Necessário para SmoothDampAngle, muda nada

    public float speed = 300, maxSpeed = 5;    // Valores defaults de movimentação. Damping em 15.

    [HideInInspector] public float hitStunTimer;

    [HideInInspector] public bool lockMovement = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        InputKey = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Q)) // Transformar isso em uma função do atacante
        {
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(Vector3.left * 50, ForceMode.Impulse);
            LockMovement();
            hitStunTimer = 0.3f;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) // Dash
        {
            rb.AddForce(transform.forward * 50, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        if (hitStunTimer > 0) hitStunTimer -= Time.fixedDeltaTime;
        else if (lockMovement) UnlockMovement();

        if (!lockMovement)
        {
            if (InputKey.magnitude > 0f)
            {
                rb.AddForce(InputKey.normalized * speed);
                if (rb.linearVelocity.magnitude >= maxSpeed) rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
        if (InputKey.magnitude >= 0.1f)
        {
            float angle = Mathf.Atan2(InputKey.x, InputKey.z) * Mathf.Rad2Deg;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref MyFloat, 0.1f);

            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        }
    }

    void LockMovement()
    {
        lockMovement = true;
    }

    void UnlockMovement()
    {
        lockMovement = false;
    }
}
