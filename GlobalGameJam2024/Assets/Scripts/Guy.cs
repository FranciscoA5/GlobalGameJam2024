using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : Character
{
    [SerializeField] float screamRange;
    float characterPositionToRunAway;

    int direction;

    GameObject woman;

    public override void Idle()
    {
        if (Input.GetKey(KeyCode.A))
        {
            SwitchState(State.Active);
        }
    }

    public override void Dead()
    {
        Die();
    }

    public override void Active()
    {
        Run(characterPositionToRunAway, direction);
        if (woman.GetComponent<Character>().GetCharacterState() == State.Reactive) GetClose(characterPositionToRunAway);
        else if (woman.GetComponent<Character>().GetCharacterState() == State.Idle) GetActions();
        //this.SwitchState(State.Idle);
    }

    public override void Reactive()
    {
        
    }

    public void Run(float xPos, int direction)
    {
        anim.SetBool("isWalking", true);
        if (woman.GetComponent<Character>().GetCharacterState() == State.Idle) 
        {
            rb2d.velocity = new Vector3(2, 0, 0) * direction;
            return;
        } 
        
        else if (xPos > transform.position.x)
        {
            rb2d.velocity = new Vector3(2, 0, 0) * direction;
            return;
        }
        rb2d.velocity = new Vector3(2, 0, 0) * -direction;
    }

    void GetClose(float xPos)
    {
        Debug.Log("Getting close");

        if (xPos + 2 < transform.position.x)
        {
            anim.SetBool("isWalking", true);
            rb2d.velocity = new Vector3(-2, 0, 0);
            return;
        }
        else if (xPos - 2 > transform.position.x)
        {
            anim.SetBool("isWalking", true);
            rb2d.velocity = new Vector3(2, 0, 0);
        }
        else 
        {
            anim.SetBool("isWalking", false);
            rb2d.velocity = new Vector2(0, 0);
        } 
    }

    void GetActions()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transf.position, screamRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.TryGetComponent<Woman>(out Woman woman))
            {
                Debug.Log("Deteta Guy");
                woman.SwitchState(State.Active);
            }
            else if (colliders[i].gameObject.TryGetComponent<Character>(out Character charac))
            {
                continue;
                Debug.Log("deteta character");
            }
        }
    }

    void Dance()
    {

    }

    void BlownAway()
    {

    }

    void Die()
    {
        //ToDo:Code to die
    }

    public void GetCharacterPosition(float _characterXPosition)
    {
        characterPositionToRunAway = _characterXPosition;
    }

    public void GetDirection(int _direction)
    {
        direction = _direction;
    }

    public void SetWoman(GameObject _woman)
    {
        woman = _woman;
    }
}
