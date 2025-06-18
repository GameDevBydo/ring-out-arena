using UnityEngine;

public class LimitBounds : MonoBehaviour
{
    MainController main;

    void Awake()
    {
        main = GameObject.FindFirstObjectByType<MainController>();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "PlayerBody")
        {
            PlayerInfo p = col.GetComponent<PlayerInfo>();
            p.playerMovement.RestartPosition();
            if (p.lastPlayerHit != null)
            {
                p.lastPlayerHit.playerPoints++;
                main.UpdatePlayerScore(p.lastPlayerHit);
                p.lastPlayerHit = null;
            }
        }
    }
}
