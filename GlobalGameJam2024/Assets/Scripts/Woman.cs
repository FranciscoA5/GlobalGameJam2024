using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woman : Character
{
    [SerializeField] private Transform center;
    [SerializeField] private float screamRange;


    public int circleSegments = 30;

    public override void Idle()
    {
        Walk();

        if (Input.GetKey(KeyCode.A))
        {
            SwitchState(State.Active);
        }
    }

    public override void Dead()
    {

    }

    public override void Active()
    {
        Scream();
    }

    public void Scream()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(center.transform.position, screamRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Fat")
            {
                // Código para Fat
            }

            if (colliders[i].gameObject.tag == "Guy")
            {
                Character guyCharacter = colliders[i].gameObject.GetComponent<Character>();
                guyCharacter.SwitchState(State.Active);
            }

            if (colliders[i].gameObject.tag == "Woman")
            {
                // Código para Woman
            }

            if (colliders[i].gameObject.tag == "Old")
            {
                // Código para character geral
            }

            if (colliders[i].gameObject.tag == "Drunk")
            {
                // Código para character geral
            }

            if (colliders[i].gameObject.tag == "Chick")
            {
                // Código para character geral
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(center.transform.position, screamRange);

        // Draw a circle to visualize the attack range
        float angleStep = 360f / circleSegments;
        Vector3 prevPos = Vector3.zero;
        for (int i = 0; i <= circleSegments; i++)
        {
            float angle = Mathf.Deg2Rad * i * angleStep;
            Vector3 newPos = center.transform.position + new Vector3(Mathf.Cos(angle) * screamRange, Mathf.Sin(angle) * screamRange, 0f);
            if (i > 0)
            {
                Gizmos.DrawLine(prevPos, newPos);
            }
            prevPos = newPos;
        }
    }
}
