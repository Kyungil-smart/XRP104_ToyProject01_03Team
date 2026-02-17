using System;
using System.Collections;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private float _coolTime;
    [SerializeField] private BulletController _bulletPrefab;
    [SerializeField] private float _attackPower;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private LayerMask _targetLayer;

    private bool _canShot;
    private WaitWhile _waitWhile;
    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

    public event Action OnFire;

    private void Awake() => Init();
    private void OnEnable() => StartCoolDownRoutine();
    private void OnDisable() => StopCoolDownRoutine();

    public void Fire()
    {
        if (!_canShot) return;

        Instantiate(_bulletPrefab)
            .SetDate(_bulletSpeed, _attackPower, _targetLayer, transform);
        
        OnFire?.Invoke();
        
        _canShot = false;
    }

    private void Init()
    {
        _waitWhile = new WaitWhile(() => _canShot);
        _waitForSeconds = new WaitForSeconds(_coolTime);
    }
    
    private void StartCoolDownRoutine()
    {
        if (_coroutine != null) return;
        
        _coroutine = StartCoroutine(CoolDownRoutine());
    }

    private void StopCoolDownRoutine()
    {
        if (_coroutine == null) return;
        
        StopCoroutine(_coroutine);
        _coroutine = null;
    }

    private IEnumerator CoolDownRoutine()
    {
        while (true)
        {
            yield return _waitWhile;
            yield return _waitForSeconds;
            _canShot = true;
        }
    }
}
