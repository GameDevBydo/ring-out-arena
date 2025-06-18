using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Other Scripts
    [HideInInspector] public PlayerCombat playerCombat;
    [HideInInspector] public PlayerMovement playerMovement;
    [HideInInspector] public Animator animator;
    [HideInInspector] public MainController main;

    // Variables

    public string playerName;
    [HideInInspector]public int playerID;
    [HideInInspector]public int playerPoints = 0;
    [HideInInspector]public PlayerInfo lastPlayerHit;
    void Awake()
    {
        playerCombat = GetComponent<PlayerCombat>();
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    
}
