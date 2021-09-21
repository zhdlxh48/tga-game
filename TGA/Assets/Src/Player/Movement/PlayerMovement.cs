using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    [SerializeField]
    private bool move = false;
    public bool isMove
    {
        get { return move; }
        set { move = value; }
    }

    protected override void CheckInput()
    {
        Vector2 direction = dir;
        if (move)
        {
            direction.x = 1.0f;
        }
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    direction.x = -1.0f;
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    direction.x = 1.0f;
        //}
        dir = direction;

        if (Input.GetKey(KeyCode.Space))
        {
            isJump = true;
        }
    }
}
