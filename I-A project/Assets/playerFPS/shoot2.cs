using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot2 : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

            if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
            {
                
                Debug.Log("je touche");
            }
        }
        
    }
}
