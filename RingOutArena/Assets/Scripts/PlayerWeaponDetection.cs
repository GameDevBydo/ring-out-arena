using UnityEngine;

public class PlayerWeaponDetection : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            var colPlayer = col.GetComponentInParent<PlayerInfo>();
            var thisPlayer = this.GetComponentInParent<PlayerInfo>();
            if (thisPlayer != colPlayer)
            {
                colPlayer.playerMovement.TakeKnockback((colPlayer.transform.position - thisPlayer.transform.position).
                normalized, thisPlayer.playerCombat.power);
                colPlayer.lastPlayerHit = thisPlayer;
            }
        }
    }
}
