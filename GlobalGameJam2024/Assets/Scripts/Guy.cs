using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : Character
{

    float characterPositionToRunAway;

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
        //RunAway(characterPositionToRunAway);
        GetClose(characterPositionToRunAway);
    }

    public override void Reactive()
    {

    }

    void RunAway(float xPos)
    {
        anim.SetBool("isWalking", true);
        if (xPos > transform.position.x)
        {
            rb2d.velocity = new Vector3(-2, 0, 0);
            return;
        }
        rb2d.velocity = new Vector3(2, 0, 0);
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
        
        //rb2d.velocity = new Vector3(-2, 0, 0);
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
}
