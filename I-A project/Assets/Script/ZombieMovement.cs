using UnityEngine;

public class ZombieMovement : MonoBehaviour
{

   private float speed = 0.2f;
    public Transform[] waypoints;

    private Transform target;
    private int destPoint = 0;
    private Animator animator;

    

    void Start()
    {
        target = waypoints[0];
        transform.LookAt(target);
        animator = GetComponent<Animator>();

    }


    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        ZombieSpeed();

        // si l'enemi est quasiment arrivé a sa destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            transform.LookAt(target);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            speed = 4f;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            speed = 0.2f;
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            speed = 0;
        }

    }


    public void ZombieSpeed()
    {
       
        //condition animation zombie avec les differentes vitesse possible
        switch(speed)
        {
            //idle
            case 0f:

                animator.SetFloat("Speed", speed);
                break;
            //walk
            case 0.2f:
                animator.SetFloat("Speed", speed);
                break;
            
            //run
            case 4.0f:
                animator.SetFloat("Speed",speed);
                break;
                
            default:
                Debug.Log("non animation");
                break;
        }

    }
}
