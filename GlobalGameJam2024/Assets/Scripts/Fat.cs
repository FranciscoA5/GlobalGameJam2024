using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fat : Character
{
    [SerializeField] private float screamRange;
    float characterPosition;

    public int circleSegments = 30;

    [SerializeField] List<GameObject> characterSpawning;
    public override void SetList(List<GameObject> _characters)
    {
        characterSpawning = _characters;
    }
    bool chasingFood;

    GameObject woman;

    private void OnMouseDown()
    {
        SwitchToIdleState(); // This line ensures that the previously first character goes back to idle state

        // Change the state of the clicked woman to active
        SwitchState(State.First);

        


    }
    public override void Active()
    {
        Debug.Log("ActiveState");
        if (woman != null && !chasingFood)
        {
            if (woman.GetComponent<Character>().GetCharacterState() == State.Reactive)
            {
                GetCloseToWomen(characterPosition);
                return;
            }
            else if (woman.GetComponent<Character>().GetCharacterState() == State.Active)
            {
                RunAwayFromWoman(characterPosition);
                return;
            }    
        }
        ChaseFood();
    }

    public override void Reactive()
    {

    }

    IEnumerator WaitToDeath()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    public override void Dead()
    {
        anim.SetBool("isDeath", true);
        StartCoroutine(WaitToDeath());

    }

    public override void Idle()
    {

    }


    public void RunAwayFromWoman(float xPos)
    {
        playerManager.AddPoints("RunAwayWoman", gameObject, 4);

        anim.SetBool("isWalking", true);

        if (xPos == 0)
        {
            rb2d.velocity = new Vector3(2, 0, 0) * 1;
            return;
        }

        else if (xPos > transform.position.x)
        {
            rb2d.velocity = new Vector3(2, 0, 0) * -1;
            return;
        }
        rb2d.velocity = new Vector3(2, 0, 0) * 1;
    }

    void GetCloseToWomen(float xPos)
    {
        playerManager.AddPoints("GetCloseWoman", gameObject, 3);

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
    }

    public void ChaseFood()
    {
        playerManager.AddPoints("ChaseFood", gameObject, 6);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transf.position, screamRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.CompareTag("Chicken"))
            {

                chasingFood = true;
                    
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
        if (inCharacterGame)
        {
            Debug.Log("Colidiu");
            if (collision.gameObject.tag != "Ground")
            {
                if (collision.gameObject.tag != "Chicken")
                {
                    if(collision.gameObject.tag == "Fat")
                    {
                        audioManager.PlaySound("FatManDeath");
                        GetComponent<Character>().SwitchState(State.Dead);
                        collision.gameObject.GetComponent<Character>().SwitchState(State.Dead);
                        return;
                    }
                    audioManager.PlaySound("FatManPush");
                    Vector2 forceDirection = new Vector2(70, 70);
                    collision.rigidbody.AddForce(forceDirection, ForceMode2D.Impulse);
                }

                else
                {
                    audioManager.PlaySound("ChickenScream");
                    collision.gameObject.GetComponent<Character>().SwitchState(State.Dead);
                }
            }
        }  
    }

    public void GetCharacterPosition(float _characterXPosition)
    {
        characterPosition = _characterXPosition;
    }

    public void SetWoman(GameObject _woman)
    {
        woman = _woman;
    }


}
