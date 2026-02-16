using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StageInfo : SceneSingleton<StageInfo>
{
    [field: SerializeField] public int StageNumber { get; private set; }
    [field: SerializeField] public GameObject Map { get; private set; }
    [field: SerializeField] public float StageTimeLimit { get; private set; }

    private HashSet<EnemyController> _enemies = new HashSet<EnemyController>();
    public bool HasRemainingEnemies => _enemies.Count > 0;

    private float _startTime;
    public float ElapsedTime => -(_startTime - Time.time);
    
    public event Action OnStageClear;
    
    private void Awake()
    {
        SceneSingletonInit();
        Init();
    }

    private void Init()
    {
        Instantiate(Map, transform);
        _startTime = Time.time;
    }

    public void AddEnemy(EnemyController enemy)
    {
        _enemies.Add(enemy);
    }

    public void RemoveEnemy(EnemyController enemy)
    {
        _enemies.Remove(enemy);
    }

    public void StageClear()
    {
        OnStageClear?.Invoke();
        
        GameClearUI clearUI;
        if (UIManager.Instance.TryGet(out clearUI))
        {
            clearUI.gameObject.SetActive(true);
            clearUI.RefreshClearTime(ElapsedTime);
        }
    }
}
