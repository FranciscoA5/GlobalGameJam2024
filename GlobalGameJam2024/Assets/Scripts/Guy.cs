using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : Character
{

    float characterPositionToRunAway;

    private void OnMouseDown()
    {
        SwitchToIdleState(); // This line ensures that the previously first character goes back to idle state

        // Change the state of the clicked woman to active
        SwitchState(State.First);


    }

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
        //RunAway(characterPositionToRunAway);
        GetClose(characterPositionToRunAway);
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
