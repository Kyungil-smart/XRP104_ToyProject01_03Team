using UnityEngine;

public class HpPotion : MonoBehaviour, IInteractable
{
    public void Interact(PlayerController controller)
    {
        controller.HealUp(10);
    }
}
