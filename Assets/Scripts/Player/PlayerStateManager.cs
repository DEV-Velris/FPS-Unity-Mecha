using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    
    public PlayerInput playerInput;
    public Rigidbody rb;

    private PlayerBaseState currentState;
    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerWalkState WalkState = new PlayerWalkState();
    public PlayerJumpState JumpState = new PlayerJumpState();

    public bool canJump = true;
    public bool crouching;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.InGame.Enable();
    }

    private void OnDisable()
    {
        playerInput.InGame.Disable();
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentState = IdleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerInput.InGame.Crouch.WasReleasedThisFrame())
        {
            transform.localScale *= 2;
        }
        currentState.UpdateState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground") && !canJump)
        {
            canJump = true;
        }
        
        currentState.OnCollisionEnterState(this, collision);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public bool IsMoving()
    {
        return playerInput.InGame.Move.IsPressed();
    }

    public bool IsJumping()
    {
        return playerInput.InGame.Jump.WasPerformedThisFrame();
    }

    public bool IsSprinting()
    {
        return playerInput.InGame.Sprint.IsPressed();
    }

    public bool IsCrouching()
    {
        return playerInput.InGame.Crouch.IsPressed();
    }

    private void OnCrouch(InputValue value)
    {
        transform.localScale /= 2;
    }
}
