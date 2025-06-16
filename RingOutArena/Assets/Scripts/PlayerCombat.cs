using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    PlayerMovement pMovement;
    Rigidbody rb;
    Animator animator;

    public float power = 15;

    [HideInInspector]public float invulTime = 0;

    [HideInInspector] public int controllerID;

    void Start()
    {
        pMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invulTime > 0) invulTime -= Time.deltaTime;
        else if (!transform.GetChild(0).gameObject.activeSelf) ShowHitbox(true);
        animator.SetBool("defendBool", pMovement.blocking);
    }

    public void OnAttack(InputValue value)
    {
        invulTime = 0;
        animator.SetTrigger("attackTrigger");
    }

    public void ShowHitbox(bool value)
    {
        transform.GetChild(0).gameObject.SetActive(value);
    }
}
