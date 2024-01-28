using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Character
{
    [SerializeField] List<GameObject> characterSpawning;

    private void OnMouseDown()
    {
        SwitchToIdleState(); // This line ensures that the previously first character goes back to idle state

        // Change the state of the clicked woman to active
        SwitchState(State.First);


    }
    public override void Active()
    {
        audioManager.PlaySound("LayingEgg");
        anim.SetBool("LayingEgg", true);
        foreach(GameObject character in characterSpawning)
        {
            if(character.tag == "Fat")
            {
                character.GetComponent<Character>().SwitchState(State.Active);
            }
        }
        currState = State.Idle;
    }

    public override void Dead()
    {
        foreach (GameObject character in characterSpawning)
        {
            if (character.tag == "Woman")
            {
                character.GetComponent<Character>().SwitchState(State.Reactive);
            }
        }
        characterSpawning.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    public override void Idle()
    {
        Walk();
    }

    public override void Reactive()
    {

    }

    public override void SetList(List<GameObject> _characters)
    {
        characterSpawning = _characters;
    }
}
