using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : Character
{

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
       
    }

    public override void Active()
    {
        Debug.Log("GUYACTIVE");
    }
}
