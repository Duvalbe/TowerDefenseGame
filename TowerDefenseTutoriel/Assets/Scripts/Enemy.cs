using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 10f; //mouvement des enemies
    private Transform[] pointsMouvement; 

    private Transform target;
    private int wavepointIndex = 0;

    public void Start ()
    {
        pointsMouvement = Waypoints.points; // récupère et stock les info de Waypoints.points
        target = pointsMouvement[0];// set le prochain point d'arret
    }

    /* 
     * calculé à chaque frame
     */
    public void Update()
    {
        // calcul du mouvement de la sphere
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //Calcul pour le changement du prochain waypoint
        float stst = Vector3.Distance(transform.position, target.position);
        if (stst <= 0.2f)
        {
            GetNextWaypoint();
        }

    }

    /* 
     * Récupère le prochain Waypoint ou détruit la sphère
     */
    public void GetNextWaypoint()
    {
        
        if (wavepointIndex >= pointsMouvement.Length - 1)
        {
            Destroy(gameObject);
        }
        else
        {
            wavepointIndex++;
            target = pointsMouvement[wavepointIndex];
        }

    }
}
