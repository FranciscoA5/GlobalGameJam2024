using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woman : Character
{
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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transf.position, screamRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.TryGetComponent<Guy>(out Guy guy))
            {
                guy.SwitchState(State.Active);
            }
            else if (colliders[i].gameObject.TryGetComponent<Character>(out Character charac))
            {
                //Código 
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
}
