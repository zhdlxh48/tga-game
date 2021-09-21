using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpLoop : PlayerState
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
    }

    public override void EndState()
    {

    }
}
