using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
    }


    public void PurchaseStandardTurret()
    {
        Debug.Log("StandardTurret Selected");
        buildManager.SetTurretToBuild(buildManager.standartTurretPrefab);
    }

    public void PurchaseMissileLauncher()
    {
        Debug.Log("MissileLauncher Selected");
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);
    }

    public void PurchaseLaserTurret()
    {
        Debug.Log("LaserTurret Selected");
        buildManager.SetTurretToBuild(buildManager.laserTurretPrefab);
    }
}
