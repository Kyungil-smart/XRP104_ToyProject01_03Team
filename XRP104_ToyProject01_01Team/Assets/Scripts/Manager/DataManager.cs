using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] private List<StageInfo> _stages = new List<StageInfo>();
    [SerializeField] private List<ItemBase> _items = new List<ItemBase>();
    
    private void Awake() => SingletonInit();

    public void LoadStage(int stageNumber)
    {
        Instantiate(_stages[stageNumber]);
    }

    public void DropRandomItem(Transform owner)
    {
        int index = Random.Range(0, _items.Count);

        Instantiate(_items[index])
            .transform
            .SetPositionAndRotation(owner.position, quaternion.identity);
    }
}
