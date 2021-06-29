using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    [SerializeField] private GameObject _boundary;
    [SerializeField] private ParticleSystem _stars;

    private float _screenAspect;

    private void Awake()
    {
        _screenAspect = (float)Screen.width / (float)Screen.height;
        InitBounds(_screenAspect);
        InitStars(_screenAspect);
    }

    private void InitBounds(float screenAspect)
    {
        GameObject northBound = Instantiate(_boundary, new Vector2(0f, Camera.main.orthographicSize + 0.5f), Quaternion.identity);
        northBound.transform.localScale = new Vector2(screenAspect * Camera.main.orthographicSize * 2f, 1f);

        GameObject southBound = Instantiate(_boundary, new Vector2(0f, -Camera.main.orthographicSize - 0.5f), Quaternion.identity);
        southBound.transform.localScale = new Vector2(screenAspect * Camera.main.orthographicSize * 2f, 1f);

        GameObject eastBound = Instantiate(_boundary, new Vector2(-screenAspect * Camera.main.orthographicSize - 0.5f, 0f), Quaternion.identity);
        eastBound.transform.localScale = new Vector2(1f, Camera.main.orthographicSize * 2f);

        GameObject westBound = Instantiate(_boundary, new Vector2(screenAspect * Camera.main.orthographicSize + 0.5f, 0f), Quaternion.identity);
        westBound.transform.localScale = new Vector2(1f, Camera.main.orthographicSize * 2f);
    }

    private void InitStars(float screenAspect)
    {
        Instantiate(_stars, new Vector2(-screenAspect * Camera.main.orthographicSize - 0.5f, 0f), Quaternion.Euler(0, 90f, -90f));
    }
}
