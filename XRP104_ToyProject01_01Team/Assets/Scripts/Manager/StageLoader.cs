using UnityEngine;

public class StageLoader : MonoBehaviour
{
    private void Awake() => Load();

    private void Load()
    {
        int stage = GameManager.Instance.CurrentStage;
        DataManager.Instance.LoadStage(stage);
    }
}
