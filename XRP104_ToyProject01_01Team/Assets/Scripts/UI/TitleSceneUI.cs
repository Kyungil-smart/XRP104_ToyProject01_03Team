using UnityEngine;

// 씬 전환을 위한 SceneManagement 네임스페이스 사용
using UnityEngine.SceneManagement;

public class TitleSceneUI : MonoBehaviour
{
    public void LoadScene(int index)
    {
        // SceneManager.LoadScene() => 빌드 설정에 포함된 인덱스 기준으로 씬 로드
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
