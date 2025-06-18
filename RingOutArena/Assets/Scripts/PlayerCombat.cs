using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    PlayerInfo playerInfo;
    public float power = 15;

    [HideInInspector]public float invulTime = 0;
    void Awake()
    {
        playerInfo = GetComponent<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invulTime > 0) invulTime -= Time.deltaTime;
        else if (!transform.GetChild(0).gameObject.activeSelf) ShowHitbox(true);
        playerInfo.animator.SetBool("defendBool",  playerInfo.playerMovement.blocking);
    }

    public void OnAttack(InputValue value)
    {
        invulTime = 0;
        playerInfo.animator.SetTrigger("attackTrigger");
    }

    public void ShowHitbox(bool value)
    {
        transform.GetChild(0).gameObject.SetActive(value);
    }
}
