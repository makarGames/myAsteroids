using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float _movingSpeed = 1f;
    [SerializeField, Range(0f, 10f)] private float _turnSpeed = 1f;

    private bool _moving;
    private float _turnDirection;

    private Rigidbody2D _rigidbody;

    public static Ship S;

    private void Awake()
    {
        if (S == null)
            S = this;

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moving = Input.GetAxis("Vertical") > 0f;
        _turnDirection = -Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (_moving)
        {
            Moving(_movingSpeed);
        }

        if (_turnDirection != 0f)
        {
            Rotation(_turnDirection, _turnSpeed);
        }
    }

    private void Moving(float speed)
    {
        _rigidbody.AddForce(transform.up * speed);
    }

    private void Rotation(float direction, float speed)
    {
        _rigidbody.AddTorque(direction * speed);
    }
}
