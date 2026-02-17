using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // [Header("Cooltime")]
    // [SerializeField][Range(0, 20)] private int _coolTime;

    private float _speed;
    private float _power;
    private LayerMask _targetLayer;
    private Transform _muzzle;
    private Rigidbody _rigidbody;

    [SerializeField] private float _deactivateDistance;


    private void Awake() => Init();
    private void FixedUpdate() => CheckDistanceFromMuzzle();
    private void OnTriggerEnter(Collider other) => TryTakeDamage(other);

    private void CheckDistanceFromMuzzle()
    {
        if (Vector3.Distance(transform.position, _muzzle.position) > _deactivateDistance)
        {
            Destroy(gameObject);
        }
    }

    public void SetDate(float speed, float power, LayerMask targetLayer, Transform muzzle)
    {
        _speed = speed;
        _power = power;
        _targetLayer = targetLayer;
        _muzzle = muzzle;

        Shot();
    }

    private void Shot()
    {
        transform.position = _muzzle.position;
        transform.rotation = _muzzle.rotation;
        _rigidbody.linearVelocity = _speed * _muzzle.forward;
    }

    private bool TryTakeDamage(Collider other)
    {
        if (((1 << other.gameObject.layer) & _targetLayer.value) == 0) return false;
        
        IDamagable damagable = other.GetComponent<IDamagable>();
        if (damagable == null) return false;
        
        damagable.TakeDamage(_power);
        Destroy(gameObject);
        return true;
    }

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    /*
    public void TakeDamage(Vector3 directionNormalized, float speed)
    {
        _rigidbody.linearVelocity = directionNormalized.normalized * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    */

}
