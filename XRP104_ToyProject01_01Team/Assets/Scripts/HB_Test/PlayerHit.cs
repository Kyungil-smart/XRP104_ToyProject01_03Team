using UnityEngine;

public class PlayerHit : MonoBehaviour, IDamagable
{
    private bool _isDead;
    private float _currentPlayerHp;
    private Animator _animator;
    private PlayerController _playerController;
    private LayerMask _layerMask;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
        _isDead = false;
    }

    public void TakeDamage(float damage)
    {
        _currentPlayerHp = _playerController._hP;

        _currentPlayerHp -= damage;

        if (_currentPlayerHp <= 0)
        {
            _isDead = true;
            _animator.SetTrigger("Die");
        }
        
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if(((1 << collision.gameObject.layer) & _layerMask.value) != 0)
        {
            
            Debug.Log("충돌");
            TakeDamage(10);
        }
    }*/
}
