using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drunk : Character
{
    private bool rage = false;
    public override void Active()
    {
        Walk();

    }

    public override void Dead()
    {

    }

    public override void Idle()
    {

        if (Input.GetKey(KeyCode.E))
        {
            SwitchState(State.Reactive);
        }
    }

    public override void Reactive()
    {
        playerManager.AddPoints("EnterRage", gameObject, 3);
        rage = true;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rage)
        {
            Vector2 forceDirection = new Vector2(30, 30);
            playerManager.AddPoints("GetHitByRage", collision.gameObject, 2);
            collision.rigidbody.AddForce(forceDirection, ForceMode2D.Impulse);
        }

    }

    public override void SetList(List<GameObject> _characters)
    {

    }
    public void Dance()
    {
        anim.SetTrigger("DrunkDance");
        playerManager.AddPoints("Dance", gameObject, 4);
    }
}
