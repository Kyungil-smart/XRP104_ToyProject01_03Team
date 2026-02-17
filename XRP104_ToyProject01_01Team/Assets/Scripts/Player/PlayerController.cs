using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour, IDamagable
{
    [SerializeField]public float _currentHp;
    public float _speed;
    
    private EPlayerState _playerState;

    public event Action OnDeath;

    private PlayerMovement _movement;
    private PlayerDetector _detector;
    private PlayerWeapon _weapon;

    private void Awake() => Init();

    private void Update()
    {
        if (!GameManager.Instance.IsGameRunning || GameManager.Instance.IsGamePaused)
        {
            return;
        }
        
        HandleState();
        HandleStateAction();
    }


    private void HandleState()
    {
        if (_movement.isMoving)
        {
            _playerState = EPlayerState.Move;
        }
        else
        {
            if (_detector.isDetected)
            {
                _playerState = EPlayerState.Attack;
            }
            else
            {
                _playerState = EPlayerState.Idle;
            }
        }
    }

    private void HandleStateAction()
    {
        if (_playerState == EPlayerState.Attack)
        {
            _movement.LookRotationTo(_detector.DetectedTarget);
            _weapon.Fire();
        }
    }

    public void HealUp(float value)
    {
        _currentHp += value;
        if (_currentHp >= 100)
        {
            _currentHp = 100;
        }

        else if(_currentHp <= 0 )
        {
            _currentHp = 0;
        }
    }

    public void SpeedUp(float speedValue)
    {
        _speed += speedValue;
    }

    public void TakeDamage(float damage)
    {
        _currentHp -= damage;

        if (_currentHp <= 0)
        {
            Die();
            GameManager.Instance.GameOver();
        }
    }

    private void Die()
    {
        OnDeath?.Invoke();
    }

    private void Init()
    {
        _movement = GetComponent<PlayerMovement>();
        _detector = GetComponentInChildren<PlayerDetector>();
        _weapon = GetComponentInChildren<PlayerWeapon>();
    }
}
