using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cane : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        /*
        if (col.gameObject.TryGetComponent<Fat>(out Fat fat))
        {
            fat.SwitchState(Fat.State.Reactive);
        }
        else if (col.gameObject.TryGetComponent<Character>(out Character charac))
        {
            charac.SwitchState(Character.State.Dead); 
        }
        */
        Destroy(gameObject);

    }
}
