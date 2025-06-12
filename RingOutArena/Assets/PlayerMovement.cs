using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.forward * Input.GetAxis("Vertical"));
    }
}
