
using UnityEngine;

public class PLayer : MonoBehaviour
{
    private float speedPlayer = 10f;
    private float sensitivity = 1.5f;
    private PLayerMotor playerMotor;
    private bool isGrounded;
    public  Vector3 jumpForce;
    public CapsuleCollider capsuleCollider;
    public LayerMask collisionLayer;


    private void Start()
    {
        playerMotor = GetComponent<PLayerMotor>();
    }
    private void Update()
    {
        //gauche/Droite
        float xMove = Input.GetAxisRaw("Horizontal");

        // avancé / reculer
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * xMove;
        Vector3 _moveVertical = transform.forward * zMove;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speedPlayer;

        playerMotor.Move(_velocity);

        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3  _Rotation = new Vector3(0, yRot, 0) * sensitivity;

        playerMotor.Rotate(_Rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");

        float _RotationX = xRot * sensitivity;

        playerMotor.RotateX(_RotationX);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            // Préparation du saut (Nécessaire en C#)
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
            v.y = jumpForce.y;

            // Saut
            gameObject.GetComponent<Rigidbody>().velocity = jumpForce;
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckCapsule(capsuleCollider.bounds.center, new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y - 0.1f, capsuleCollider.bounds.center.z), 0.08f, collisionLayer);
    }


}
