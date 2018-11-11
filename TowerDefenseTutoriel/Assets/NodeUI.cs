using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {
    private Node target;
    public GameObject ui;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
