using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualization : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> _sprites;
    [SerializeField] private List<MeshRenderer> _models;

    private void Start()
    {
        ChangeVisability.S.AddVisualization(this);
        ChangeVisualization(ChangeVisability.S.vision);
    }

    public void Deleting()
    {
        ChangeVisability.S.RemoveVisualization(this);
    }

    public void ChangeVisualization(bool vision)
    {
        if (vision)
        {
            _sprites[Random.Range(0, _sprites.Count)].enabled = vision;
            foreach (MeshRenderer mR in _models)
                mR.enabled = !vision;
        }
        else
        {
            _models[Random.Range(0, _models.Count)].enabled = !vision;
            foreach (SpriteRenderer sR in _sprites)
                sR.enabled = vision;
        }
    }
}
