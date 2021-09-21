using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpDown : PlayerState
{
    public override void StartState()
    {

    }

    private void FixedUpdate()
    {
        if (!manager.movement.isJump)
        {
            if (manager.movement.isMove)
            {
                manager.ChangeState(PlayerStateType.RUN);
                return;
            }
        }
        else
        {
            Vector2 vel = manager.rig.velocity;
            if (vel.normalized.y > 0.0f)
            {
                manager.ChangeState(PlayerStateType.JUMPUP);
                return;
            }
        }
    }

    public override void EndState()
    {

    }
}
