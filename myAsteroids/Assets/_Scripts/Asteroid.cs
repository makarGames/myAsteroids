using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField, Range(0f, 60f)] private float _lifeTime = 12f;
    [SerializeField, Range(0f, 50f)] private float _speed = 10f;

    [SerializeField] private GameObject _asteroidPrefab;

    private Rigidbody2D _rigidbody;
    private Transform _transform;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }
    private void Start()
    {
        _transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);

        Destroy(gameObject, _lifeTime);
    }

    public void SetTrajectory(Vector2 direction)
    {
        _rigidbody.AddForce(direction * _speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            if (_transform.localScale.x > 0.7f)
            {
                CreateSplit();
                CreateSplit();
            }
            Destroy(other.gameObject);
            GetComponent<Destroing>().Destroy();
        }

    }

    private void CreateSplit()
    {
        Vector2 position = _transform.position;
        position += Random.insideUnitCircle * 0.5f;

        GameObject little = Instantiate(_asteroidPrefab, position, _transform.rotation);
        little.transform.localScale = _transform.localScale * 0.5f;
        little.GetComponent<Asteroid>().SetTrajectory(Random.insideUnitCircle.normalized);
    }
}
