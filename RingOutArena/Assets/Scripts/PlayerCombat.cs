using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    PlayerMovement pMovement;
    Rigidbody rb;
    Animator animator;

    void Start()
    {
        pMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.all[0].buttonWest.wasPressedThisFrame) animator.SetTrigger("attackTrigger");
        animator.SetBool("defendBool", Gamepad.all[0].leftShoulder.isPressed);
    }
}
