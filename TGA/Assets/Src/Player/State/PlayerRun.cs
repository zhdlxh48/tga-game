using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : PlayerState
{
    public override void StartState()
    {

    }

    private void FixedUpdate()
    {
        if (manager.movement.isJump)
        {
            manager.ChangeState(PlayerStateType.JUMPUP);
            return;
        }
    }

    public override void EndState()
    {

    }
}
