using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fat : Character
{
    [SerializeField] private float screamRange;
    public int circleSegments = 30;

    [SerializeField] List<GameObject> characterSpawning;
    public void SetList(List<GameObject> _characters)
    {
        characterSpawning = _characters;
    }

    private void OnMouseDown()
    {
        SwitchToIdleState(); // This line ensures that the previously first character goes back to idle state

        // Change the state of the clicked woman to active
        SwitchState(State.First);

        


    }
    public override void Active()
    {
        chaseFood();
    }

    public override void Reactive()
    {

    }

    public override void Dead()
    {

    }

    public override void Idle()
    {

    }

    public void chaseFood()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transf.position, screamRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.CompareTag("Chicken"))
            {
            
                if (colliders[i].gameObject.transform.position.x  < transform.position.x)
                {
                    anim.SetBool("isWalking", true);
                    rb2d.velocity = new Vector3(-2, 0, 0);
                    return;
                }
                else if (colliders[i].gameObject.transform.position.x  > transform.position.x)
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
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transf.position, screamRange);

        // Draw a circle to visualize the attack range
        float angleStep = 360f / circleSegments;
        Vector3 prevPos = Vector3.zero;
        for (int i = 0; i <= circleSegments; i++)
        {
            float angle = Mathf.Deg2Rad * i * angleStep;
            Vector3 newPos = transf.position + new Vector3(Mathf.Cos(angle) * screamRange, Mathf.Sin(angle) * screamRange, 0f);
            if (i > 0)
            {
                Gizmos.DrawLine(prevPos, newPos);
            }
            prevPos = newPos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "Ground")
        {
            if (collision.gameObject.tag != "Chicken")
            {

                Vector2 forceDirection = new Vector2(70, 70);
                collision.rigidbody.AddForce(forceDirection, ForceMode2D.Impulse);

            }
        }


        if (collision.gameObject.tag == "Chicken")
        {
            characterSpawning.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }

    }
    


}
