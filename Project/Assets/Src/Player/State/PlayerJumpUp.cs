using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpUp : PlayerState
{
    public override void StartState()
    {

    }

    private void FixedUpdate()
    {
        Vector2 vel = manager.rig.velocity;
        if (vel.normalized.y < 0.0f)
        {
            manager.ChangeState(PlayerStateType.JUMPDOWN);
            return;
        }
        else if (vel.normalized.y > 0.0)
        {
            manager.ChangeState(PlayerStateType.JUMPLOOP);
            return;
        }
    }

    public override void EndState()
    {

    }
}
