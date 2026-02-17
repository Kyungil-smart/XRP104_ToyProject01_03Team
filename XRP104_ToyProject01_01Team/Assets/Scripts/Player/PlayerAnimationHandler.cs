using Unity.VisualScripting;
using UnityEngine;

// TODO: 플레이어 구현 로직에 따라 수정 필요함
public class PlayerAnimationHandler : MonoBehaviour
{
    private readonly int IsMoving = Animator.StringToHash("IsMoving");
    private readonly int IsAim = Animator.StringToHash("IsAim");
    private readonly int Shoot = Animator.StringToHash("Shoot");
    private readonly int Die = Animator.StringToHash("Die");

    private PlayerMovement _movement;
    private PlayerController _controller;
    private PlayerWeapon _weapon;
    private Animator _animator;
    
    private void Awake() => Init();
    private void OnEnable() => SubscribeActions();
    private void OnDisable() => UnsubscribeActions();
    
    private void Init()
    {
        _movement = GetComponent<PlayerMovement>();
        _controller = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
        _weapon = GetComponentInChildren<PlayerWeapon>();
    }

    private void SubscribeActions()
    {
        _controller.OnDeath += OnDie;
        _movement.OnMove += OnMovePlayer;
        _weapon.OnFire += OnShoot;
    }

    private void UnsubscribeActions()
    {
        _controller.OnDeath -= OnDie;
        _movement.OnMove -= OnMovePlayer;
        _weapon.OnFire -= OnShoot;
    }

    private void OnMovePlayer(bool isMoving) 
        => _animator.SetBool(IsMoving, isMoving);

    private void OnAim(bool isAiming)
        => _animator.SetBool(IsAim, isAiming);

    private void OnShoot()
        => _animator.SetTrigger(Shoot);

    private void OnDie()
        => _animator.SetTrigger(Die);
}
