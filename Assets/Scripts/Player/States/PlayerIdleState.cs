using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("J'suis en Idle mon pote");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.IsMoving())
        {
            player.SwitchState(player.WalkState);
        } else if (player.IsJumping() && player.canJump)
        {
            player.SwitchState(player.JumpState);
        }
    }

    public override void OnCollisionEnterState(PlayerStateManager player, Collision collision)
    {
        
    }
}
