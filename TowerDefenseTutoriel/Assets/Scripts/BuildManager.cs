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

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUi;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUi.SetTarget(node);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUi.Hide();
    }
}
