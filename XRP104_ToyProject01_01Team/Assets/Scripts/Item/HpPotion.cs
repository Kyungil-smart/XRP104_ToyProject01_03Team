using UnityEngine;

public class HpPotion : ItemBase, IInteractable
{
    [SerializeField] [Range(1, 100)] private float _healValue;
    
    private void Awake() => Init();
    private void OnEnable() => Drop();
    
    protected override void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Interact(PlayerController controller)
    {
        controller.HealUp(_healValue);
        Destroy(gameObject);
    }
}
