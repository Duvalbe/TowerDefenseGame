/*
 * Classe qui récupère en statique les références de chaque Waypoint
 * Placé sur l'objet parent "Waypoints"
 * permet d'avoir la liste de référence des Waypoints pour les mouvements des ennemies
 * L'ennemi n'a pas besoin de rechercher les Waypoints dans le monde, il les connait déjà avec cette référence
 */

using UnityEngine;

public class Waypoints : MonoBehaviour {
    public static Transform[] points; // "public static" accès à cette variable par tout les scripts

    /* Awake fonction :
     * Appelé lorsque l'instance du script est chargé
     * permet d'intialiser variables ou paramètres d'état avant que la partie ne commence
     */
    void Awake()
    {
        points = new Transform[transform.childCount]; //créer un Array suivant le nombre d'enfant dans Waypoints
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i); // place les infos de position/rotation/taille dans chaque case de chaque enfant
        }
    }
}


//Tout les objets de la scène on un "Transform", c'est utilisé pour stockeret manipuler les positions/rotation/taille
//"transform" sans maj == le "Transform" attaché à ce GameObject
