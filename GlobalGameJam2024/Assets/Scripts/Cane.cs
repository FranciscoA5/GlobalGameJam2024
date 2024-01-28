using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cane : MonoBehaviour
{
    PlayerManager playerManager;

    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent<Character>(out Character charac))
        {
            playerManager.AddPoints("DieByCane", charac.gameObject, 3);
            charac.SwitchState(Character.State.Dead); 
        }

        Destroy(gameObject);
    }
}
