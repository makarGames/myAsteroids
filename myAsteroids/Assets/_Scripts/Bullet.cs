using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Range(0f, 1000f)] private float _speed = 50f;
    [SerializeField, Range(0f, 60f)] private float _lifeTime = 12f;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Project(transform.up);
        Destroy(gameObject, _lifeTime);
    }

    public void Project(Vector2 direction)
    {
        _rigidbody.AddForce(direction * _speed);
    }

    /* private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Enemy>() || other.gameObject.GetComponent<Asteroid>())
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    } */
}
