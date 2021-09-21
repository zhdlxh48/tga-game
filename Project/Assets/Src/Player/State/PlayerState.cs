using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    protected PlayerStateManager manager;

    protected virtual void Awake()
    {
        manager = GetComponent<PlayerStateManager>();
    }

    public abstract void StartState();
    public abstract void EndState();
}
