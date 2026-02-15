using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _turnSpeed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float direction = Input.GetAxisRaw("Vertical");

        Vector3 newVelocity = new Vector3
        {
            x = transform.forward.x * _moveSpeed * direction,
            y = _rigidbody.linearVelocity.y,
            z = transform.forward.z * _moveSpeed * direction
        };

        _rigidbody.linearVelocity = newVelocity;
    }

    private void Rotation()
    {
        
    }
}
