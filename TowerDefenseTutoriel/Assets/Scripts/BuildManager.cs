using UnityEngine;

public class BuildManager : MonoBehaviour {

    //singleton pattern
    public static BuildManager instance; //enregistre un référence de lui même

    /*
     * A chaque fois qu'on démarre le jeu une seul instance de buildmanager existe!
     */
    void Awake()
    {
        instance = this;
    }

    public GameObject standartTurretPrefab;
    public GameObject missileLauncherPrefab;
    public GameObject laserTurretPrefab;
    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
