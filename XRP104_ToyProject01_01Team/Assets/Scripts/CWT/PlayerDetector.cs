using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    // [SerializeField] private float _rayLength;
    // [SerializeField] private LayerMask _targetLayer;

    // private Ray _ray;
    private Transform _detectedTarget;
    public bool isDetected => _detectedTarget != null;

    // private float minDistance = float.MaxValue;

    private List<GameObject> _targets = new List<GameObject>();

    private void FixedUpdate()
    {
        if (_targets == null || _targets.Count == 0) return;

        Transform closeTarget = GetClosestTargetTransform();
        
        RayShot(closeTarget);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _targets.Remove(other.gameObject);
            
            if(_targets.Count == 0) _detectedTarget = null;
        }
    }

    private void OnDrawGizmos()
    {
        if (_detectedTarget == null) return;
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, _detectedTarget.position);

        // Gizmos.DrawRay(_ray.origin, _ray.direction * _rayLength);
    }

    // dd
    private void RayShot(Transform target)
    {
        Vector3 vectorToTarget = target.position - transform.position;
        Vector3 dir = vectorToTarget.normalized;
        float distance = vectorToTarget.magnitude;
        
        Ray ray = new Ray(transform.position, dir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            if(hit.transform.CompareTag("Enemy"))
            {
                _detectedTarget = hit.transform;
            }
            else
            {
                _detectedTarget = null;
            }
        }
        else
        {
            _detectedTarget = null;
        }
    }

    private Transform GetClosestTargetTransform()
    {
        if (_targets == null || _targets.Count == 0) return null;
        
        Transform target = _targets[0].transform;
        float distance = Vector3.Distance(transform.position, target.position);

        for (int i = 1; i < _targets.Count; i++)
        {
            float CurrDist = Vector3.Distance(transform.position, _targets[i].transform.position);

            if (CurrDist < distance)
            {
                distance = CurrDist;
                target = _targets[i].transform;
            }
        }
        
        return target;
    }


    /*
    private void DectectTarget()
    {
        foreach (GameObject enemy in _closeTarget.transform)
        {
            float _distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (minDistance > _distance)
            {
                _closeTarget = enemy.transform;
                minDistance = _distance;
            }
        }
    }*/
}
