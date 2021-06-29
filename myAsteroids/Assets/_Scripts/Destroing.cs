using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroing : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionPrefab;
    [SerializeField] private int awardPoints = 10;

    public void Destroy()
    {
        Score.S.AddScore(awardPoints);
        ParticleSystem explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

        if (GetComponent<Ship>())
            gameObject.SetActive(false);
        else
        {
            GetComponent<Visualization>().Deleting();
            Destroy(gameObject);
        }
    }
}
