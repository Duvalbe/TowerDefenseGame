/*
 * En charge du mouvement des ennemis d'une place à l'autre
 */

using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 10f; //mouvement des ennemies, peut être ajuster dans l'éditeur
    private Transform[] pointsMouvement; 

    private Transform target; // le prochain point d'arrivé du déplacement
    private int wavepointIndex = 0; // indice du Waypoint à récupérer dans la liste de la Classe Waypoint

    /*
     * Action du lancement de la partie
     */
    public void Start ()
    {
        pointsMouvement = Waypoints.points; // récupère et stock les info de Waypoints.points
        target = pointsMouvement[0];// set le prochain point d'arret
    }

    /* 
     * calculé à chaque frame
     * Determine la nouvelle position de l'Ennemi
     */
    public void Update()
    {
        // calcul du mouvement de la sphere
        Vector3 dir = target.position - transform.position; // direction à regarder pour atteindre le WayPoint
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);//Mouvement de l'ennemi, nouvelle position

        //Calcul pour le changement du prochain waypoint
        float stst = Vector3.Distance(transform.position, target.position);// permet de définir si l'ennemi est arrivé au waypoint
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
            Destroy(gameObject);//la destruction d'un object peut prendre du temps du coup on utilise un return pour finir le script
            return;
        }
        else
        {
            wavepointIndex++;
            target = pointsMouvement[wavepointIndex];
        }

    }
}

//"Vector3" utiliser par unity pour passer les informations 3D de position et direction
// propriété : magnitude(longueur) / normalized (magnitude of 1, permet d'avoir toujours la même magnitude)
//"transform.Translate(Vector3)" déplace le transform dans la direction et la distance de translation
//"Space.World"  permet de notifier que le transform dépend du system de coordonnée du monde
