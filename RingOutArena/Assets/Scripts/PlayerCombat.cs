using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    PlayerMovement pMovement;
    Rigidbody rb;

    [SerializeField] GameObject weaponStates;
    int weaponStateId; // 0 = Idle, 1 = Ataque, 2 = Defesa

    void Start()
    {
        pMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) weaponStateId = 1;
        else if (Input.GetKey(KeyCode.Mouse1)) weaponStateId = 2;
        else weaponStateId = 0;
    }


    void FixedUpdate()
    {
        ShowWeaponState();
    }

    void ShowWeaponState()
    {
        for (int i = 0; i < weaponStates.transform.childCount; i++)
        {
            if(i == weaponStateId) weaponStates.transform.GetChild(i).gameObject.SetActive(true);
            else weaponStates.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
