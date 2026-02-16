using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _turnSpeed;

    private Rigidbody _rigidbody;

    Vector3 _moveMent;
    public bool isMoving => _moveMent != Vector3.zero;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleMovement();
        Rotation();
        Move();
    }

    private void Move()
    {
        if (_moveMent == Vector3.zero) return;
        _rigidbody.linearVelocity = transform.forward * _moveSpeed;
    }

    private void Rotation()
    {
        if (_moveMent == Vector3.zero) return;
        transform.rotation = Quaternion.LookRotation(_moveMent);

    }

    private void HandleMovement()
    {
        float z = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");

        _moveMent = new Vector3 (x,0,z).normalized;
    }
}
