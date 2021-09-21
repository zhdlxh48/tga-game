using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemMoveType
{
    UpDown,
    LeftRight,
    OnlyLeft,
    OnlyRight,
    OnlyUp,
    OnlyDown,
}

public class ItemMovement : MonoBehaviour
{
    public ItemMoveType type;

    public float maxDist;
    public float moveSpeed;

    public float dir = 1.0f;

    public bool isFlash = false;
    public bool isSameFlash = true;
    public float onFlashTime = 0.0f;
    public float offFlashTime = 0.0f;

    public float flashDelay = 0.0f;

    private float currTime = 0.0f;

    private Vector2 startPos;
    private SpriteRenderer sr;

    private void Awake()
    {
        startPos = transform.position;
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float moveDist = moveSpeed * Time.deltaTime;
        Vector2 pos = transform.position;

        switch (type)
        {
            case ItemMoveType.LeftRight: pos.x += dir * moveDist; break;
            case ItemMoveType.UpDown: pos.y += dir * moveDist; break;
            case ItemMoveType.OnlyLeft: pos.x -= moveDist; break;
            case ItemMoveType.OnlyRight: pos.x += moveDist; break;
            case ItemMoveType.OnlyUp: pos.y += moveDist; break;
            case ItemMoveType.OnlyDown: pos.y -= moveDist; break;
        }

        if (type == ItemMoveType.LeftRight ||
            type == ItemMoveType.UpDown)
        {
            float currDist = pos.magnitude - startPos.magnitude;
            if (Mathf.Abs(currDist) >= maxDist)
            {
                dir *= -1.0f;
            }
        }

        transform.position = pos;


        if (isFlash)
        {
            currTime += Time.deltaTime;
            Debug.Log(currTime);
            if (isSameFlash)
            {
                if (currTime >= flashDelay)
                {
                    if (sr.enabled)
                        sr.enabled = false;
                    else
                        sr.enabled = true;
                    currTime = 0.0f;
                }
            }
            else
            {
                if (sr.enabled)
                {
                    if (currTime >= onFlashTime)
                    {
                        sr.enabled = false;
                        currTime = 0.0f;
                    }
                }
                else
                {
                    if (currTime >= offFlashTime)
                    {
                        sr.enabled = true;
                        currTime = 0.0f;
                    }
                }

            }
        }
    }
}
