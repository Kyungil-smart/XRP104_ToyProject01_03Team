using UnityEngine;

public class CameraSetter : MonoBehaviour
{
    private Camera _mainCam;
    [SerializeField][Range(0, 90)] private float _virtialAngleRange;
    public bool _hasCameraControl { get; set; }

    private void Awake() => Init();

    private void LateUpdate()
    {
        SetPosition();
        SetRotateX();
    }

    private void Init()
    {
        _mainCam = Camera.main;
        _hasCameraControl = true;
    }

    private void SetPosition()
    {
        if(!_hasCameraControl) return;
        _mainCam.transform.position = transform.position;
    }

    private void SetRotateX()
    {
        _mainCam.transform.rotation = Quaternion.Euler(
            _virtialAngleRange,
            _mainCam.transform.rotation.eulerAngles.y,
            _mainCam.transform.rotation.eulerAngles.z
            );
    }
}
