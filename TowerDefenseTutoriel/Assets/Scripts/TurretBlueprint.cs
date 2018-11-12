using UnityEngine;

[System.Serializable] // pour etre visible dans l'inspecteur
public class TurretBlueprint {
    public GameObject prefab;
    public int cost;
    public GameObject upgradedPrefab;
    public int upgradeCost;
    public int GetSellAmount()
    {
        return cost / 2;
    }
}
