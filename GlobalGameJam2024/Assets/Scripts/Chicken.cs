using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Character
{
    public override void Active()
    {
        
    }

    public override void Dead()
    {
     
    }

    public override void Idle()
    {
        Walk();
    }
}
