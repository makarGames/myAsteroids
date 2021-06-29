using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _playerTransform;
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        _playerTransform = Ship.S.GetComponent<Transform>();
        InitMovement();
    }

    private void InitMovement()
    {
        Vector3 startPos = _transform.position;
        Vector3 endPos = _playerTransform.position;

        StartCoroutine(Movement(startPos, endPos));
    }

    private IEnumerator Movement(Vector3 startPos, Vector3 endPos)
    {
        float moveRatio = 0f;
        while (moveRatio <= 1.15)
        {
            _transform.position = Vector2.LerpUnclamped(startPos, endPos, moveRatio);
            moveRatio += 1f / 250f;
            yield return new WaitForFixedUpdate();
        }
        InitMovement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            Destroy(other.gameObject);
            GetComponent<Destroing>().Destroy();
        }
    }
}
