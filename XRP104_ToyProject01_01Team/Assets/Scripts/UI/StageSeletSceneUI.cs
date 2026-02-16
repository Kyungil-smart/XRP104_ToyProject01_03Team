using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSeletSceneUI : MonoBehaviour
{
    public void LoadGameScene(int stageNumber)
    {
        // TODO : 스테이지 로드를 위한 로직 불러와야 함.
        SceneManager.LoadScene(2);
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene(0);
    }
}
