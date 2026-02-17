using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private PlayerController _controller;

    private void Awake() => Init();
    private void OnTriggerEnter(Collider other) => TryInteract(other);

    private void Init()
    {
        _controller = GetComponentInParent<PlayerController>();
    }

    private bool TryInteract(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable == null) return false;
        
        interactable.Interact(_controller);
        return true;
    }
}
