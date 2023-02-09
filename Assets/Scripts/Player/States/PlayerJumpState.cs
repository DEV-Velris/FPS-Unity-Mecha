using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Je jump");
        player.rb.velocity += Vector3.up * 5;
        player.canJump = false;
        if (player.IsMoving())
        {
            player.SwitchState(player.WalkState);
        }
        else
        {
            player.SwitchState(player.IdleState);
        }
    }

    public override void UpdateState(PlayerStateManager player)
    {
    }

    public override void OnCollisionEnterState(PlayerStateManager player, Collision collision)
    {
    }
}
