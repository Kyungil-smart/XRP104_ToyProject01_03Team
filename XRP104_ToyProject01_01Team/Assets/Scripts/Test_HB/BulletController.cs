using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Cooltime")]
    [SerializeField][Range(0, 20)] private int _coolTime;
    //[SerializeField] private float _damage;
    private Rigidbody _rigidbody;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void TakeDamage(Vector3 directionNormalized, float speed)
    {
        _rigidbody.linearVelocity = directionNormalized.normalized * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        {
            {
                Destroy(gameObject);
            }
        }
    }

}
