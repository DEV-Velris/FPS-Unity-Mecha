using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Jsuis en Walk State");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.IsMoving())
        {
            Vector2 move = player.playerInput.InGame.Move.ReadValue<Vector2>();
            Vector3 moveTotal = new Vector3(move.x, 0, move.y);
            var movement = player.transform.TransformDirection(moveTotal);
            movement *= 5 * Time.deltaTime;
            if (!player.IsSprinting())
            {
                if (!player.IsCrouching())
                {
                    player.transform.position += movement;
                }
                else
                {
                    player.transform.position += movement * 0.5f;
                }
            }
            else
            {
                if (!player.IsCrouching())
                {
                    player.transform.position += movement*2;
                }
                else
                {
                    player.transform.position += movement;
                }
            }
            if (player.IsJumping() && player.canJump)
            {
                player.SwitchState(player.JumpState);
            }
        }
        else
        {
            player.SwitchState(player.IdleState);
        }
    }

    public override void OnCollisionEnterState(PlayerStateManager player, Collision collision)
    {
        
    }
}
