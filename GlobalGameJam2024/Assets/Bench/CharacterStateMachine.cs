using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Rendering;
using static GuyStateMachine;
public class CharacterStateMachine : MonoBehaviour
{
    public CharacterState currentState;
    public IdleState idleState;
    public ActiveState activeState;
    public ReactiveState reactiveState;
    public DeadState deadState;

    public string currentStateName;

    private void Awake()
    {
        idleState = new IdleState(this);
        activeState = new ActiveState(this);
        reactiveState = new ReactiveState(this);
        deadState = new DeadState(this);

        // Set an initial state
        currentState = idleState;
        currentStateName = $"{currentState}";
        currentState.OnEnter();
    }

    private void Update()
    {
        // Check if currentState is not null before calling OnUpdate
        if (currentState != null)
        {
            currentState.OnUpdate();
        }
    }

    public void SwitchState(CharacterState newState)
    {
        currentState?.OnExit();
        currentState = newState;
        currentStateName = $"{currentState}";
        currentState.OnEnter();
    }
}



