using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PunchlineButton : MonoBehaviour
{
    GameObject canvasObject;
    CharacterSpawning characterSpawning;


    // Start is called before the first frame update
    void Start()
    {
         canvasObject = GameObject.Find("Canvas");
         characterSpawning = canvasObject.GetComponent<CharacterSpawning>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonClickin()
    {
       foreach(GameObject character in characterSpawning.characterList)
        {
            Character characterScript = character.GetComponent<Character>();
            if(characterScript.GetCharacterState() == Character.State.First)
            {
                Debug.Log(characterScript);
                characterScript.SwitchState(Character.State.Active);
                GameManager.Instance.UpdateGameState(GameState.Joke);
                
            }
        }

        StartCoroutine("EndPunchline");
    }

    IEnumerator EndPunchline()
    {
        yield return new WaitForSeconds(10f);
        MeetingData.finalJokePoints = FindAnyObjectByType<PlayerManager>().GetJokePoints();
        MeetingData.counterValue = 3;
        SceneManager.LoadScene("MeetingRoom");
    }
}
