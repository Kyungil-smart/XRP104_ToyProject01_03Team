using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]public float _hP;
    public float _speed;
    IInteractable interactable;
    
    private void OnTriggerEnter(Collider other)
    {
        interactable = other.GetComponent<IInteractable>();
        if (interactable == null) return;
        
        if (interactable != null)
        {
            interactable.Interact(this);
        }

    }

    public void HealUp(float value)
    {
        _hP += value;
        if (_hP >= 100)
        {
            _hP = 100;
        }

        else if(_hP <= 0 )
        {
            _hP = 0;
        }
        
    }

    public void SpeedUp(float speedValue)
    {
        _speed += speedValue;
    }
}
