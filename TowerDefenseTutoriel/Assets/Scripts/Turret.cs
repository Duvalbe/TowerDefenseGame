using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;

    [Header("Attributes")] // organize in unit the information

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);//action de recherche de la target (Name méthode, début, incrément)
	}

    /* 
     * nouvelle recherche de target, recherche sur tout les objets marqués comme ennemis
     * trouve le plus proche, check si il est dans la range, set target = to cet objet
     * ne pas faire ca frame by frame (trop de calcul) donc méthode hors update()
     */
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (target == null)
            return;

        //Target Lock on 
        //First : get un arrow qui pointe dans la direction de l'ennemi
        Vector3 dir = target.position - transform.position; // show la direction qu'on point.
        Quaternion lookRotation = Quaternion.LookRotation(dir);  //la manière dont unité gère les rotations
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;//Lerp : unity methode. Smooth transition d'un état à l'autre
        partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);
        
        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    /* 
     * montre sur unity la range
     */
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
