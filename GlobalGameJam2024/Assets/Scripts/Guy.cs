using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : Character
{
    public override void Idle()
    {
        Walk();
    }

    public override void Dead()
    {
       
    }

    public override void Active()
    {
        Debug.Log("Guy is Active");
    }
}
