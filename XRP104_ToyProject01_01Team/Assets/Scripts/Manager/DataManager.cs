using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private List<StageInfo> _stages = new List<StageInfo>();
    
    private void Awake() => SingletonInit();

    public void LoadStage(int stageNumber)
    {
        Instantiate(_stages[stageNumber]);
    }
}
