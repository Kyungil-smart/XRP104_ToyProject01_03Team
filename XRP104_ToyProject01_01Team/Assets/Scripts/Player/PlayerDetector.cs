using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerDetector : MonoBehaviour
{
    // [SerializeField] private float _rayLength;
    // [SerializeField] private LayerMask _targetLayer;

    // private Ray _ray;
    public Transform DetectedTarget { get; private set; }
    public bool isDetected => DetectedTarget != null;

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
            
            if(_targets.Count == 0) DetectedTarget = null;
        }
    }

    private void OnDrawGizmos()
    {
        if (DetectedTarget == null) return;
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, DetectedTarget.position);

        // Gizmos.DrawRay(_ray.origin, _ray.direction * _rayLength);
        
    }
    private void RayShot(Transform target)
    {
        if (target == null) return;
        
        Vector3 vectorToTarget = target.position - transform.position;
        Vector3 dir = vectorToTarget.normalized;
        float distance = vectorToTarget.magnitude;
        
        Ray ray = new Ray(transform.position + new Vector3(0, 1, 0), dir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            if(hit.transform.CompareTag("Enemy"))
            {
                DetectedTarget = hit.transform;
            }
            else
            {
                DetectedTarget = null;
            }
        }
        else
        {
            DetectedTarget = null;
        }
    }

    private Transform GetClosestTargetTransform()
    {
        if (_targets == null || _targets.Count == 0) return null;

        Transform target = null;
        float distance;

        for (int i = 0; i < _targets.Count; i++)
        {
            if (_targets[i] == null) continue;
            
            target = _targets[i].transform;
            distance = Vector3.Distance(transform.position, target.position);

            if (i == 0) continue;
            
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
