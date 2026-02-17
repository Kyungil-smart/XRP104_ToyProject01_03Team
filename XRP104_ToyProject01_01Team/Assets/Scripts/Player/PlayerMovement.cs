using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _turnSpeed;

    private Rigidbody _rigidbody;

    Vector3 _moveMent;
    public bool isMoving => _moveMent != Vector3.zero;

    private bool _prevTickIsMoving;

    public event Action<bool> OnMove;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _prevTickIsMoving = false;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGameRunning || GameManager.Instance.IsGamePaused)
        {
            _rigidbody.linearVelocity = Vector3.zero;
            return;
        }

        HandleMovement();
        Rotation();
        Move();
    }

    private void Move()
    {
        if (_moveMent == Vector3.zero)
        {
            MoveStop();
        }
        else
        {
            MoveTick();
        }
    }

    private void MoveStop()
    {
        _rigidbody.linearVelocity = Vector3.zero;
        if(_prevTickIsMoving != isMoving) OnMove?.Invoke(isMoving);
    }

    private void MoveTick()
    {
        _rigidbody.linearVelocity = transform.forward * _moveSpeed;
        if(_prevTickIsMoving != isMoving) OnMove?.Invoke(isMoving);
    }

    private void Rotation()
    {
        if (_moveMent == Vector3.zero) return;
        transform.rotation = Quaternion.LookRotation(_moveMent);
    }

    public void LookRotationTo(Transform target)
    {
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(target.position - transform.position),
            0.05f
            );
    }

    private void HandleMovement()
    {
        _prevTickIsMoving = isMoving;
        
        float z = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");

        _moveMent = new Vector3 (x,0,z).normalized;
    }
}
