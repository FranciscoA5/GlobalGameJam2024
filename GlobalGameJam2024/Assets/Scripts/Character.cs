using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    protected Animator anim;

    public enum State
    {
        Idle,
        Dead,
        Active
    }

    protected Character(State startingState = State.Idle)
    {
        currState = startingState;
    }


    protected State currState;

    public abstract void Idle();

    public abstract void Dead();

    public abstract void Active();

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        switch (currState)
        {
            case State.Idle:
                Idle();
                break;
            case State.Dead:
                Dead();
                break;
            case State.Active:
                Active();
                break;
        }
    }

    protected void SwitchState(State newState)
    {
        currState = newState;
    }

    protected float walkTimer = 0;
    protected void Walk()
    {
        if (walkTimer >= 2f)
        {
            int walkState = Random.Range(0, 3);
            switch (walkState)
            {
                case 0:
                    rb2d.velocity = Vector3.zero;
                    break;
                case 1:
                    rb2d.velocity = new Vector3(1, 0, 0);
                    break;
                case 2:
                    rb2d.velocity = new Vector3(-1, 0, 0);
                    break;
            }
            walkTimer = 0;
        }
        walkTimer += Time.deltaTime;

        if (rb2d.velocity.x > 0 || rb2d.velocity.x < 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
