using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterMovement : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rb;
    public Rigidbody2D rig
    {
        get { return rb; }
    }

    public float moveSpeed;
    public float maxSpeed;

    public float jumpPower;

    public bool isBlockVelocity;
    public bool isInversFlip;
    //public bool isStartingMaxPower;

    private bool isStartJump = false;

    public bool isJump
    {
        get;
        protected set;
    }

    public Vector2 dir
    {
        get;
        protected set;
    }

    private void Awake()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckInput();
        Jump();
        Move();
    }

    private void Jump()
    {
        if (isJump)
        {
            if (!isStartJump)
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                isStartJump = true;
            }
        }
    }

    private void Move()
    {
        Vector2 velocity = rig.velocity;
        Vector2 moveVelocity = Vector2.zero;
        float absVelocityX = Mathf.Abs(velocity.x);

        if (dir.x == 0.0f)
        {
            if (isBlockVelocity)
            {
                velocity.x = 0.0f;
                rb.velocity = velocity;
            }
        }
        else
        {
            if (isInversFlip)
            {
                float signX = velocity.x / absVelocityX;
                if (!float.IsNaN(signX) && signX != dir.x)
                {
                    velocity.x *= -1;
                    rb.velocity = velocity;
                }
            }
        }

        if (absVelocityX < maxSpeed)
        {
            //if (!isStartingMaxPower)
            //{
                float deviation = maxSpeed - absVelocityX;
                if (deviation >= moveSpeed * Time.deltaTime)
                {
                    moveVelocity = dir * moveSpeed;
                    rb.AddForce(moveVelocity, ForceMode2D.Force);
                }
                else
                {
                    moveVelocity = dir * deviation;
                    rb.AddForce(moveVelocity, ForceMode2D.Impulse);
                }
            //}
            //else
            //{
            //    if(absVelocityX < maxSpeed)
            //        velocity.x = maxSpeed * dir.x;
            //    rb.velocity = velocity;
            //}
        }

        dir = Vector2.zero;
    }

    protected abstract void CheckInput();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RaycastHit2D[] rh = Physics2D.RaycastAll(transform.position, Vector2.down);
        foreach (RaycastHit2D hit in rh)
        {
            if (hit.transform.gameObject == collision.gameObject)
            {
                isJump = false;
                isStartJump = false;
            }
        }
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (isGrounded)
    //        return;

    //    RaycastHit2D[] rh = Physics2D.RaycastAll(transform.position, Vector2.down);
    //    foreach (RaycastHit2D hit in rh)
    //    {
    //        if (hit.transform.gameObject == collision.gameObject)
    //        {
    //            isGrounded = true;
    //            //isJump = false;
    //            //isStartJump = false;
    //        }
    //    }
    //}
}
