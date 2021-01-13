
using UnityEngine;

public class BarreDeSort : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("joueur"))
        {
        IA_Waypoint.joueurVu = true;

        }
    }
}
