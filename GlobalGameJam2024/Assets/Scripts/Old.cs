using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old : Character
{
    public Transform caneThrowSpot;
    public Transform caneOrigin;
    public GameObject canePrefab;
    public GameObject caneVisual;
    public float throwForce;
    public float caneLifeSpan;

    private bool hasCane = true;
    private Vector2 caneThrowDirection;

    private void OnMouseDown()
    {
        SwitchToIdleState(); // This line ensures that the previously first character goes back to idle state

        // Change the state of the clicked woman to active
        SwitchState(State.First);


    }
    private void Awake()
    {
        caneThrowDirection = caneThrowSpot.position - transform.position;
        GameObject child = gameObject.transform.GetChild(0).gameObject;

        Animator animation = GetComponentInChildren<Animator>();
    }

    public override void Idle()
    {
        if (Input.GetKey(KeyCode.D))
        {
            SwitchState(State.Active);
        }
    }

    public override void Dead()
    {

    }

    public override void Active()
    {
        
        anim.SetBool("isActive", true);
        ThrowCane();
    }

    private void ThrowCane()
    {
        if (hasCane)
        {
            GameObject newCane = Instantiate(canePrefab, caneOrigin.position, Quaternion.identity);
            Rigidbody2D caneRb = newCane.GetComponent<Rigidbody2D>();

            if (caneRb != null)
            {
                caneRb.AddForce(caneThrowDirection * throwForce, ForceMode2D.Impulse);
                float i = 0;
                StartCoroutine(DestroyCaneAfterDelay(newCane, caneLifeSpan));
            }
            hasCane = false;
            caneVisual.SetActive(false);
        }
    }

    IEnumerator DestroyCaneAfterDelay(GameObject caneObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(caneObject);
    }
}
