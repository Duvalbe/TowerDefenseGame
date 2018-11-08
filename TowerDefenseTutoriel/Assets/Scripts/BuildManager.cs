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

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn (Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret Build ! money left: "+ PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }


}
