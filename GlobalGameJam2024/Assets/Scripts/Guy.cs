using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : Character
{
    [SerializeField] float collideRange;
    float characterPositionToRunAway;

    private void OnMouseDown()
    {
        SwitchToIdleState(); // This line ensures that the previously first character goes back to idle state

        // Change the state of the clicked woman to active
        SwitchState(State.First);


    }
    int direction = 1;

    GameObject woman;

    public override void Idle()
    {
        Walk();
    }

    public override void Dead()
    {
        Die();
    }

    public override void Active()
    {
        if (woman != null)
        {
            if (woman.GetComponent<Character>().GetCharacterState() == State.Reactive) GetClose(characterPositionToRunAway);
            else if (woman.GetComponent<Character>().GetCharacterState() == State.Idle) GetActions();
        }
        RunAway(characterPositionToRunAway, direction);
    }

    public override void Reactive()
    {

    }

    void RunAway(float xPos, int direction)
    {
        playerManager.AddPoints("RunAway", gameObject, 5);
        Debug.Log("Points Added");
        anim.SetBool("isWalking", true);

        if (xPos == 0)
        {
            rb2d.velocity = new Vector3(2, 0, 0) * direction;
            return;
        }

        else if (xPos > transform.position.x)
        {
            rb2d.velocity = new Vector3(2, 0, 0) * -direction;
            return;
        }
        rb2d.velocity = new Vector3(2, 0, 0) * direction;
    }

    void GetClose(float xPos)
    {
        playerManager.AddPoints("GetClose", gameObject, 3);
        Debug.Log("Getting close");

        if (xPos + 3 < transform.position.x)
        {
            anim.SetBool("isWalking", true);
            rb2d.velocity = new Vector3(-2, 0, 0);
            return;
        }
        else if (xPos - 3 > transform.position.x)
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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transf.position, collideRange);
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

    public void SetWoman(GameObject _women)
    {
        woman = _women;
    }

    public override void SetList(List<GameObject> _characters)
    {
        
    }
}
