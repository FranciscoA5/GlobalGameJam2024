using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyStateMachine : MonoBehaviour
{
    public abstract class CharacterState
    {
        protected CharacterStateMachine characterStateMachine;
        public CharacterState(CharacterStateMachine character)
        {
            characterStateMachine = character;
        }

        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnExit();
    }

    public class IdleState : CharacterState
    {
        public IdleState(CharacterStateMachine character) : base(character) { }

        public override void OnEnter()
        {

        }

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.A)) 
            {
                characterStateMachine.SwitchState(characterStateMachine.activeState);
            }
        }

        public override void OnExit()
        {

        }
    }
    public class ActiveState : CharacterState
    {
        private Rigidbody2D rb2D;
        public float moveSpeed = 5f;

        public ActiveState(CharacterStateMachine character) : base(character)
        {
            rb2D = character.GetComponent<Rigidbody2D>();
            if (rb2D == null)
            {
                Debug.LogError("Rigidbody2D component not found on GameObject.");
            }
        }

        public override void OnEnter()
        {
        }

        public override void OnUpdate()
        {
            if (rb2D != null)
            {
                // Move the GameObject to the left
                MoveLeft();
                Debug.Log("Move to the left");
            }
            else
            {
                Debug.LogError("Rigidbody2D component not found on GameObject.");
            }
        }

        public override void OnExit()
        {
        }

        private void MoveLeft()
        {
            rb2D.velocity = new Vector2(-moveSpeed, rb2D.velocity.y);
        }
    }
    public class ReactiveState : CharacterState
    {
        public ReactiveState(CharacterStateMachine character) : base(character) { }

        public override void OnEnter()
        {

        }

        public override void OnUpdate()
        {

        }

        public override void OnExit()
        {

        }
    }
    public class DeadState : CharacterState
    {
        public DeadState(CharacterStateMachine character) : base(character) { }

        public override void OnEnter()
        {

        }

        public override void OnUpdate()
        {

        }

        public override void OnExit()
        {

        }
    }
}