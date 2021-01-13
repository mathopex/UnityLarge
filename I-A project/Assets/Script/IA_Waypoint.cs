using UnityEngine.AI;
using UnityEngine;

public class IA_Waypoint : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public Transform target;
    public int destPoint = 0;
    public enum typeMouvement {loop, reverse, random};
    public typeMouvement typeDeMouvement;
    public static bool joueurVu = false;
    public Rigidbody rb;
    RaycastHit hit;


    private GameObject joueur;
    void Start()
    {
        target = waypoints[destPoint = Random.Range(0, waypoints.Length)];
        transform.LookAt(target);
        joueur = GameObject.FindGameObjectWithTag("joueur");
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

        ;

        if (!joueurVu)
        {
            FindPlayer();
        }
        Marcher();

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.red);
       
    }

    private void Marcher()
    {
        if (joueurVu)
        {
            transform.LookAt(joueur.transform.position);
            Vector3 dirJoueur = joueur.transform.position - transform.position;
            transform.Translate(dirJoueur.normalized * speed * Time.deltaTime, Space.World);
            if( Vector3.Distance(transform.position, joueur.transform.position) <= 5f)
            {
                speed = 0;
                rb.isKinematic = true;
                print(" tu es mort AH AH AH AH AH!!!!!!");
            }
            
            else if (Vector3.Distance(transform.position, joueur.transform.position) > 5f)
            {
                speed = 10;
                rb.isKinematic = false;
            }
        }

        else
        {
            //deplacement autonome de l'objet
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if (typeDeMouvement == typeMouvement.loop)
            {
                Loop();
            }
            else if (typeDeMouvement == typeMouvement.reverse)
            {
                Reverse();
            }
            else
            {
                Randome();
            }
        }
    }
    // deplacement en boucle positive
    private void Loop()
    {
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            transform.LookAt(target); 
        }
    }

    // deplacement en boucle negative
    private void Reverse()
    {
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint - 1) % waypoints.Length;
           if(destPoint < 0)
            {
                destPoint = waypoints.Length - 1;
            }
            target = waypoints[destPoint];
            transform.LookAt(target);
        }
    }

    //deplacement aleatoir entre les points
    private void Randome()
    {
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = Random.Range(0, waypoints.Length);
            target = waypoints[destPoint];
            transform.LookAt(target);
        }
    }


    private void FindPlayer()
    {
        if (Vector3.Distance(transform.position, joueur.transform.position) < 0.1f)
        {
            joueurVu = true;
        }
    }
}


    
       
    
