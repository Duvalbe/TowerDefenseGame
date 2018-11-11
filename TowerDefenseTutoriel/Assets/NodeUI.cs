using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {
    private Node target;
    public GameObject ui;
    public Text upgradeCost;
    public Button upgradeButton;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        } else
        {
            upgradeCost.text = "UPGRADED";
            upgradeButton.interactable = false;
        }
            

        
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpdateTurret();
        BuildManager.instance.DeselectNode();
        
    }
}
