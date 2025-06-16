using UnityEngine;

public class PlayerWeaponDetection : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            var colPlayer = col.GetComponentInParent<PlayerMovement>();
            var thisPlayer = this.GetComponentInParent<PlayerMovement>();
            if (thisPlayer != colPlayer)
            {
                var playerCombat = thisPlayer.gameObject.GetComponent<PlayerCombat>();
                colPlayer.TakeKnockback((colPlayer.transform.position - thisPlayer.transform.position).normalized,
                playerCombat.power);
            }
        }
    }
}
