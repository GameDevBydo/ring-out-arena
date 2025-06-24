using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInfo : MonoBehaviour
{
    // Other Scripts
    [HideInInspector] public PlayerCombat playerCombat;
    [HideInInspector] public PlayerMovement playerMovement;
    [HideInInspector] public Animator animator;
    [HideInInspector] public MainController main;

    // Variables

    public string playerName;
    [HideInInspector] public int playerID;
    [HideInInspector] public int playerPoints = 0;
    [HideInInspector] public PlayerInfo lastPlayerHit;
    public PlayerClassInfo pClassInfo;
    void Awake()
    {
        playerCombat = GetComponent<PlayerCombat>();
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        ChangeInputMap(1);
    }

    public void ChangeInputMap(int value) // 0 = Player, 1 = UI
    {
        if (value == 0)
        {
            GetComponent<PlayerInput>().actions.FindActionMap("Player").Enable();
            GetComponent<PlayerInput>().actions.FindActionMap("UI").Disable();
        }
        else
        {
            GetComponent<PlayerInput>().actions.FindActionMap("UI").Enable();
            GetComponent<PlayerInput>().actions.FindActionMap("Player").Disable();
        }
    }

    void UpdateClassValues(PlayerClassInfo cInfo)
    {
        playerCombat.power = cInfo.classPower;
        playerMovement.defenseScale = cInfo.classDefense;
    }

}
