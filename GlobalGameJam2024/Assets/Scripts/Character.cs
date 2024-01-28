using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    protected Animator anim;
    protected Transform transf;
    protected int characterClicked = 0;
    private SpriteRenderer spriteRenderer;
    protected AudioManager audioManager;

    protected bool inCharacterGame;

    void Awake()
    {
        GameManager.OnGameStateChange += GameManagerOnGameStateChange;
       
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= GameManagerOnGameStateChange;
    }

    private void GameManagerOnGameStateChange(GameState state)
    {
        inCharacterGame = state == GameState.Joke;
    }

    public enum State
    {
        Idle,
        Dead,
        Active,
        Reactive,
        First
    }

    protected Character(State startingState = State.Idle)
    {
        currState = startingState;
    }


    protected State currState;

    public abstract void Idle();

    public abstract void Dead();

    public abstract void Active();

    public abstract void Reactive();

    public State GetCharacterState()
    {
        return currState;
    }

    private static Character currentFirstCharacter; // Static variable to keep track of the currently first character

    protected void SetCurrentFirstCharacter(Character newFirstCharacter)
    {
        // Set the new active character
        currentFirstCharacter = newFirstCharacter;
        spriteRenderer.color = Color.red;
    }

    protected void SwitchToIdleState()
    {
        // Switch the current first character to idle state
        if (currentFirstCharacter != null && currentFirstCharacter != this)
        {
            
            currentFirstCharacter.SwitchState(State.Idle);
            
        }

        // Set the current character as the new active character
        SetCurrentFirstCharacter(this);
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        transf = transform;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {

        if (inCharacterGame)
        {
            Debug.Log("GameStateJoke");
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
                case State.Reactive:
                    Reactive();
                    break;
            }
        
        }
        if (currState != State.First)
        {
            spriteRenderer.color = Color.white;
        }
    }

    public void SwitchState(State newState)
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
