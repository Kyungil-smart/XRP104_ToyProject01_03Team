using UnityEngine;

public class SpeedPotion : ItemBase, IInteractable
{
    [SerializeField] [Range(1, 50)] private float _speedUpValue;

    private void Awake() => Init();
    private void OnEnable() => Drop();
    
    protected override void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Interact(PlayerController controller)
    {
        controller.SpeedUp(_speedUpValue);
        Destroy(gameObject);
    }
}
