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
                col.GetComponentInParent<PlayerKnockback>().
                TakeKnockback((colPlayer.transform.position - thisPlayer.transform.position).normalized);
            }
        }
    }
}
