using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSeletSceneUI : MonoBehaviour
{
    public void LoadGameScene(int stageNumber)
    {
        GameManager.Instance.CurrentStage = stageNumber;
        SceneManager.LoadScene(2);
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene(0);
    }
}
