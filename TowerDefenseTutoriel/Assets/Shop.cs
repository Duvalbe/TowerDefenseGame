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

    public void PurchaseRocketTurret()
    {
        Debug.Log("RocketTurret Selected");
        buildManager.SetTurretToBuild(buildManager.rocketTurretPrefab);
    }

    public void PurchaseLaserTurret()
    {
        Debug.Log("LaserTurret Selected");
        buildManager.SetTurretToBuild(buildManager.laserTurretPrefab);
    }
}
