using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field: SerializeField] public int CurrentStage { get; set; }
    
    private void Awake()
    {
        SingletonInit();
    }
}
