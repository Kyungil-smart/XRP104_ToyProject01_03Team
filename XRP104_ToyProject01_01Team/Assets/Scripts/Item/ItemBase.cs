using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class ItemBase : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] protected float _xzDropForce;
    [SerializeField] [Range(0, 10)] protected float _yDropForce;
    protected Rigidbody _rigidbody;
    
    public void Drop()
    {
        float force = Random.Range(0, _xzDropForce);
        
        _rigidbody.AddForce(new Vector3(force, _yDropForce, force), ForceMode.Impulse);
    }
    
    protected abstract void Init();
}
