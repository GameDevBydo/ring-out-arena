using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    Rigidbody rb;
    PlayerMovement pMovement;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //pMovement = GetComponent<PlayerMovement>();
    }

    public void TakeKnockback(Vector3 dir)
    {
        rb.linearVelocity = Vector3.zero;
        rb.AddForce(dir * 15, ForceMode.Impulse);
        //pMovement.LockMovement();
        //pMovement.hitStunTimer = 0.3f;
    }
}
