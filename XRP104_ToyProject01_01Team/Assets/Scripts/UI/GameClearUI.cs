using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClearUI : MonoBehaviour, IUI
{
    [SerializeField] private TextMeshProUGUI _clearTime;
    [SerializeField] private Button _titleButton;
    
    private void Awake() => Init();
    private void OnEnable() => _titleButton.onClick.AddListener(ToTitle);
    private void OnDisable() => _titleButton.onClick.RemoveListener(ToTitle);
    private void OnDestroy() => UIManager.Instance.Unregister<GameClearUI>();
    
    private void Init()
    {
        UIManager.Instance.Register(this);
        gameObject.SetActive(false);
    }

    public void RefreshClearTime(float time)
    {
        _clearTime.text = $"Clear Time : {time.ToString("0.00")} sec";
    }

    private void ToTitle()
    {
        SceneManager.LoadScene(0);
    }
}
