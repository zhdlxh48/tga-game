using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateType
{
    RUN = 0,
    JUMPUP,
    JUMPLOOP,
    JUMPDOWN,
    NONE,
}

public class PlayerStateManager : MonoBehaviour {

    private Dictionary<PlayerStateType, PlayerState> states;

    public Rigidbody2D rig;
    public PlayerMovement movement;
    public Animator anim;

    public PlayerStateType currentType;
    public PlayerStateType startType;

    private void Awake()
    {
        states = new Dictionary<PlayerStateType, PlayerState>();
        states[PlayerStateType.JUMPLOOP] = GetComponent<PlayerJumpLoop>();
        states[PlayerStateType.RUN] = GetComponent<PlayerRun>();
        states[PlayerStateType.JUMPUP] = GetComponent<PlayerJumpUp>();
        states[PlayerStateType.JUMPDOWN] = GetComponent<PlayerJumpDown>();

        rig = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        ChangeState(startType);
    }

    public void ChangeState(PlayerStateType change)
    {
        foreach (KeyValuePair<PlayerStateType, PlayerState> pair in states)
        {
            pair.Value.enabled = false;
        }

        if (currentType != PlayerStateType.NONE)
        {
            states[currentType].EndState();
        }

        currentType = change;
        states[change].enabled = true;
        states[change].StartState();
        anim.SetInteger("State", (int)change);
    }
}
