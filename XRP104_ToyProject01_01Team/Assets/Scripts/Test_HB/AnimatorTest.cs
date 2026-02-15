using TMPro;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            _animator.SetInteger("Aim", _animator.GetInteger("Aim") == 1 ? 0 : 1);
        }

        if (Input.GetMouseButton(0))
        {
            if (_animator.GetInteger("Aim") > 0)
            {
                _animator.SetTrigger("Attack");
                Debug.Log("좌클릭, 공격");
            }
        }
    }
}
