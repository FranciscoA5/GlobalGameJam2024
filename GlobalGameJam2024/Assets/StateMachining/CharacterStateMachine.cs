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
    }

    private void Update()
    {
        currentState.OnUpdate();
    }

    public void SwitchState(CharacterState newState)
    {
        currentState?.OnExit();
        currentState = newState;
        currentStateName = $"{currentState}";
        currentState.OnEnter();
    }
}



