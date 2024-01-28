using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woman : Character
{
    [SerializeField] private float screamRange;

    public int circleSegments = 30;

    

    private void OnMouseDown()
    {
        SwitchToIdleState(); // This line ensures that the previously first character goes back to idle state

        // Change the state of the clicked woman to active
        SwitchState(State.First);


    }

    public override void Idle()
    {
        Walk();
        GetCollisions(1);
        anim.SetBool("isScreaming", false);
        anim.SetBool("isWalking", true);
    }

    public override void Dead()
    {

    }

    public override void Active()
    {
        
        Scream();
    }

    public override void Reactive()
    {
        Cry();
    }

    void GetCollisions(int direction)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transf.position, screamRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.TryGetComponent<Guy>(out Guy guy))
            {
                guy.GetCharacterPosition(transform.position.x);
                guy.GetDirection(direction);
                guy.SetWoman(gameObject);
                guy.SwitchState(State.Active);
            }

            else if(colliders[i].gameObject.TryGetComponent<Fat>(out Fat fat))
            {
                fat.GetCharacterPosition(transform.position.x);
                fat.SetWoman(gameObject);
                fat.SwitchState(State.Active);
            }

            else if (colliders[i].gameObject.TryGetComponent<Woman>(out Woman woman))
            {
                if(woman.GetComponent<Character>().GetCharacterState() == State.Active)
                {
                    SwitchState(State.Active);
                }
            }

            else if(colliders[i].gameObject.TryGetComponent<Old>(out Old old))
            {
                if (GetComponent<Character>().GetCharacterState() == State.Active || GetComponent<Character>().GetCharacterState() == State.Reactive)
                {
                    Debug.Log("OldReactive");
                    old.SwitchState(State.Reactive);
                }
            }

            else if (colliders[i].gameObject.TryGetComponent<Chicken>(out Chicken chicken))
            {
                if (GetCharacterState() == State.Active)
                {
                    chicken.GetComponent<Character>().SwitchState(State.Active);
                }
            }

            else if (colliders[i].gameObject.TryGetComponent<Character>(out Character charac))
            {
                //C�digo 
            }
        }
    }

    public void Scream()
    {
        audioManager.PlaySound("WomanScream");
        anim.SetBool("isScreaming", true);
        GetCollisions(-1);
        SwitchState(State.Idle);    
  
    }

    public void Cry()
    {
        anim.SetBool("isCrying", true);
        audioManager.PlaySound("WomanCry");
        GetCollisions(1);
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, screamRange);

        // Draw a circle to visualize the attack range
        float angleStep = 360f / circleSegments;
        Vector3 prevPos = Vector3.zero;
        for (int i = 0; i <= circleSegments; i++)
        {
            float angle = Mathf.Deg2Rad * i * angleStep;
            Vector3 newPos = transform.position + new Vector3(Mathf.Cos(angle) * screamRange, Mathf.Sin(angle) * screamRange, 0f);
            if (i > 0)
            {
                Gizmos.DrawLine(prevPos, newPos);
            }
            prevPos = newPos;
        }
    }
    */
}
