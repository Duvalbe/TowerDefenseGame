using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMouvement : MonoBehaviour {

    private Transform target; // le prochain point d'arrivé du déplacement
    private int wavepointIndex = 0; // indice du Waypoint à récupérer dans la liste de la Classe Waypoint

    private Transform[] pointsMouvement;
    private Enemy enemy;
    /*
     * Action du lancement de la partie
     */
    public void Start()
    {
        enemy = GetComponent<Enemy>();
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
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);//Mouvement de l'ennemi, nouvelle position

        //Calcul pour le changement du prochain waypoint
        float stst = Vector3.Distance(transform.position, target.position);// permet de définir si l'ennemi est arrivé au waypoint
        if (stst <= 0.5f)
        {
            GetNextWaypoint();
        }
        enemy.speed = enemy.startSpeed;
    }

    /* 
     * Récupère le prochain Waypoint ou détruit la sphère
     */
    public void GetNextWaypoint()
    {

        if (wavepointIndex >= pointsMouvement.Length - 1)
        {
            EndPath();
            return;
        }
        else
        {
            wavepointIndex++;
            target = pointsMouvement[wavepointIndex];
        }

    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);//la destruction d'un object peut prendre du temps du coup on utilise un return pour finir le script
    }
}
