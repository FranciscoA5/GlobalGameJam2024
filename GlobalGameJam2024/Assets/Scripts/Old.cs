using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old : Character
{
    public Transform caneThrowSpot;
    public Transform peeCenter;
    public GameObject canePrefab;
    public GameObject caneVisual;
    public GameObject peeLine;
    public float throwForce;
    public float caneLifeSpan;
    public float peeRange;
    public float victimForce;

    public int circleSegments = 30;

    private bool hasCane = true;
    private Vector2 caneThrowDirection;

    
    private void OnMouseDown()
    {
        SwitchToIdleState(); // This line ensures that the previously first character goes back to idle state

        // Change the state of the clicked woman to active
        SwitchState(State.First);


    }
    //private void Awake()
    //{
    //    //caneThrowDirection.x = caneThrowSpot.position.x - transform.position.x;
    //    //caneThrowDirection.y = caneThrowSpot.position.y;
    //    //GameObject child = gameObject.transform.GetChild(0).gameObject;

    //    //Animator animation = GetComponentInChildren<Animator>();
    //}

    public override void Idle()
    {
        //if (Input.GetKey(KeyCode.A))
        //{
        //    SwitchState(State.Active);
        //}

        //if (Input.GetKey(KeyCode.F))
        //{
        //    SwitchState(State.Reactive);
        //}
    }

    public override void Dead()
    {

    }

    public override void Active()
    {
        Debug.Log("OldActive");
        anim.SetBool("isActive", true);
        ThrowCane();
        anim.SetBool("isActive", true);
        
    }

    public override void Reactive()
    {
        GameObject pee = Instantiate(peeLine, peeCenter.position, Quaternion.identity);
        pee.transform.localScale = new Vector3(peeRange * 2, 0.362f, 1);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(peeCenter.position, peeRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.TryGetComponent<Guy>(out Guy guy) ||
                colliders[i].gameObject.TryGetComponent<Chicken>(out Chicken chicken) ||
                colliders[i].gameObject.TryGetComponent<Fat>(out Fat fat))     
            {
                Rigidbody2D vRb = colliders[i].gameObject.GetComponent<Rigidbody2D>();
                RunAwayFromPee(transform, colliders[i].gameObject.transform, vRb);
            }
            else if (colliders[i].gameObject.TryGetComponent<Character>(out Character charac))
            {  
                charac.SwitchState(State.Reactive);
            }
        }
    }

    private void ThrowCane()
    {
        audioManager.PlaySound("CaneThrowing");
        caneThrowDirection.x = caneThrowSpot.position.x - transform.position.x;
        caneThrowDirection.y = 0;
        if (hasCane)
        {
           
            GameObject newCane = Instantiate(canePrefab, caneThrowSpot.position, Quaternion.identity);
            Rigidbody2D caneRb = newCane.GetComponent<Rigidbody2D>();

            if (caneRb != null)
            {
                caneRb.AddForce(caneThrowDirection * throwForce, ForceMode2D.Impulse);
                StartCoroutine(DestroyCaneAfterDelay(newCane, caneLifeSpan));
            }
            hasCane = false;
            caneVisual.SetActive(false);
            currState = State.Idle;
        }
    }



    private void RunAwayFromPee(Transform oldPosition, Transform victimPosition, Rigidbody2D victimRb) 
    {
        Vector2 direction = victimPosition.position - oldPosition.position;
        /*
        if (direction.x < 0)
        {
            direction = direction.normalized;
        }
        */
        
        victimRb.AddForce(direction * victimForce, ForceMode2D.Impulse);
    }

    IEnumerator DestroyCaneAfterDelay(GameObject caneObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(caneObject);
    }

    public override void SetList(List<GameObject> _characters)
    {
        throw new System.NotImplementedException();
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(peeCenter.position, peeRange);

        // Draw a circle to visualize the attack range
        float angleStep = 360f / circleSegments;
        Vector3 prevPos = Vector3.zero;
        for (int i = 0; i <= circleSegments; i++)
        {
            float angle = Mathf.Deg2Rad * i * angleStep;
            Vector3 newPos = peeCenter.position + new Vector3(Mathf.Cos(angle) * peeRange, Mathf.Sin(angle) * peeRange, 0f);
            if (i > 0)
            {
                Gizmos.DrawLine(prevPos, newPos);
            }
            prevPos = newPos;
        }
    }
    */
}
