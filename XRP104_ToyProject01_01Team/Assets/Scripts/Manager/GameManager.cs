using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field: SerializeField] public int CurrentStage { get; set; }
    public event Action OnGameStart;
    
    
    private void Awake()
    {
        SingletonInit();
    }

    public void GameStart()
    {
        OnGameStart?.Invoke();
    }
}
