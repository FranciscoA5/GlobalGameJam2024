using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drunk : Character
{

    private void OnMouseDown()
    {
        SwitchToIdleState(); // This line ensures that the previously first character goes back to idle state

        // Change the state of the clicked woman to active
        SwitchState(State.First);


    }
    public override void Active()
    {
        Walk();
    }

    public override void Dead()
    {

    }

    public override void Idle()
    {

    }

    public override void Reactive()
    {

    }

    public override void SetList(List<GameObject> _characters)
    {
        throw new System.NotImplementedException();
    }
}
