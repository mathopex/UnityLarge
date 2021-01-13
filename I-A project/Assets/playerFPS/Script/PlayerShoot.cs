using JetBrains.Annotations;
using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShoot : MonoBehaviour

{
    public AudioClip soundShoot;
    private Ray ray;
    private RaycastHit hit;
    private Physics Test;
    public int distance;
    public LayerMask environmentMask;
    private float nextFire;
    public float Shoot = 3;


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<AudioSource>().PlayOneShot(soundShoot);
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            ray = Camera.main.ScreenPointToRay(screenCenterPoint);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                //if (hit.transform.gameObject.CompareTag("enemi"))
                {
                   // Debug.Log(hit.distance);

                }

            }
        }
    }
}
