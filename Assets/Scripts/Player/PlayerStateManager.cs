using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    private PlayerBaseState currentState;
    private PlayerIdleState IdleState = new PlayerIdleState();
    private PlayerWalkState WalkState = new PlayerWalkState();
    private PlayerSprintState SprintState = new PlayerSprintState();
    private PlayerCrouchState CrouchState = new PlayerCrouchState();
    private PlayerJumpState JumpState = new PlayerJumpState();
    private PlayerLyingDownState LyingDownState = new PlayerLyingDownState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
