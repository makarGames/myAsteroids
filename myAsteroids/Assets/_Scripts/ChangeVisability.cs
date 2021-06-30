using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVisability : MonoBehaviour
{
    private List<Visualization> _visualization = new List<Visualization>();

    public bool vision { get; private set; } // true - 2d Visualization, false - 3d Visualization 

    public static ChangeVisability S;

    private void Awake()
    {
        vision = true;
        if (S == null)
            S = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
            Change();
    }

    public void AddVisualization(Visualization v)
    {
        _visualization.Add(v);
    }

    public void RemoveVisualization(Visualization v)
    {
        _visualization.Remove(v);
    }

    private void Change()
    {
        vision = !vision;
        foreach (Visualization v in _visualization)
        {
            v.ChangeVisualization(vision);
        }
    }
}
