using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
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
}
