using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMotor : MonoBehaviour
{
    public Camera cam;
    private Vector3 velocity;
    private Rigidbody rb;
    private Vector3 rotation;
    private float RotationX = 0f;
    private float currentRotationX = 0f;
    private float RotationLimit = 85f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PerformeMove();
        PerformeRotation();
    }

    private void FixedUpdate()
    {
        
    }

    public void Move(Vector3 _velocity)
    {

        velocity = _velocity;
        
    }

    private void PerformeMove()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
    }

    public void Rotate(Vector3 _Rotation)
    {
        rotation = _Rotation;
    }

    public void RotateX(float _RotationX)
    {
        RotationX = _RotationX;
    }
    private void PerformeRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        currentRotationX -= RotationX;
        currentRotationX = Mathf.Clamp(currentRotationX, -RotationLimit, RotationLimit);

        // Applique les changements à la caméra après le clamp
        cam.transform.localEulerAngles = new Vector3(currentRotationX, 0f, 0f);
        //applique le mouvement sur l'arme et les bras

       
    }


}
