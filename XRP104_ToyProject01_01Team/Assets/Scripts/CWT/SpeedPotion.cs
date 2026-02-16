using UnityEngine;

public class SpeedPotion : MonoBehaviour, IInteractable
{
    public void Interact(PlayerController controller)
    {
        controller.SpeedUp(20);
    }
}
