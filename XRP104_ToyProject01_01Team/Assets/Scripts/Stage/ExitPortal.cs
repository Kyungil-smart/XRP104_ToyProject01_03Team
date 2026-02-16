using Unity.VisualScripting;
using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    [SerializeField] private LayerMask _playerMask;
    
    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _playerMask.value) == 0) return;
        
        SetGameClear();
    }

    private void SetGameClear()
    {
        if (StageInfo.Instance.HasRemainingEnemies) return;

        GameManager.Instance.StageClear();
    }
}
