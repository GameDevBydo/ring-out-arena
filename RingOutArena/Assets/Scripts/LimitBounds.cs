using UnityEngine;

public class LimitBounds : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "PlayerBody")
        {
            col.GetComponent<PlayerMovement>().RestartPosition();
        }
    }
}
