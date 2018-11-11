/*
 * En charge du mouvement des ennemis d'une place à l'autre
 */

using UnityEngine;

public class Enemy : MonoBehaviour {
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed; //mouvement des ennemies, peut être ajuster dans l'éditeur

    public float health = 100f;//Vie de l'ennemy
    public int worth = 50; // l'argent gagner en le tuant
    public GameObject deathEffect;// a quoi ca ressemble quand il meurt    

    public void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    private void Die()
    {
        PlayerStats.Money += worth;

        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}

//"Vector3" utiliser par unity pour passer les informations 3D de position et direction
// propriété : magnitude(longueur) / normalized (magnitude of 1, permet d'avoir toujours la même magnitude)
//"transform.Translate(Vector3)" déplace le transform dans la direction et la distance de translation
//"Space.World"  permet de notifier que le transform dépend du system de coordonnée du monde
