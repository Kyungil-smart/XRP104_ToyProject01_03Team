using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField]private PlayerStates _currentState = PlayerStates.Idle;

    private PlayerMovement playerMovement;
    private PlayerDetector playerDetector;
    private Animator _animator;

    private enum PlayerStates
    {
        Idle, Move, Attack
    }

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerDetector = GetComponent<PlayerDetector>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    private void PlayerStateCheck()
    {
        if (playerMovement.isMoving)
        {
            _currentState = PlayerStates.Move;
        }

        else if (playerDetector.isDetected)
        {
            _currentState = PlayerStates.Attack;
        }
        
        else
            _currentState = PlayerStates.Idle;
    }
}
