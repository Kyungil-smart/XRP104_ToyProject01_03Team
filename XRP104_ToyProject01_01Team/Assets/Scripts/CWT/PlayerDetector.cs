using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float _rayLength;
    [SerializeField] private LayerMask _targetLayer;

    private Ray _ray;
    private Transform _closeTarget;

    private float minDistance = float.MaxValue;
    
    private List<GameObject> _target = new List<GameObject>();

    private void Update()
    {
        RayShot();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("타겟 들어옴");
            _target.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("타겟 나감");
            _target.Remove(other.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(_ray.origin, _ray.direction * _rayLength);
    }

    private void RayShot()
    {
        
        _ray = new Ray(transform.position,);

        RaycastHit hit;

        if (Physics.Raycast(_ray, out hit, _rayLength))
        {
            if(hit.transform.CompareTag("Enemy"))
            {
                Debug.Log($"{hit.transform.name} 감지");
            }
            
        }
    }


    private void DectectTarget()
    {
        // 1. 가까운 적 탐색하여 트랜스폼 필드변수에 담아두기
        
        foreach (GameObject enemy in _closeTarget.transform)
        {
            float _distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (minDistance > _distance)
            {
                _closeTarget = enemy.transform;
                minDistance = _distance;
            }
        }
    }
}
