using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class CharacterSpawning : MonoBehaviour
{
    //usados para as funcoes dos botoes
    [SerializeField] private bool[] characterSelected = new bool[6];

    //prefabs a serem instanciados
    [SerializeField] private GameObject[] charactersPrefabs = new GameObject[6];

    public List<GameObject> characterList;

    void Start()
    {
        //o jogo começa com todos os botoes a serem falsos
        for (int i = 0; i < 6; i++)
        {
            characterSelected[i] = false;
        }

      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            spawnCharacter();
        }
    }

    public void womanSelectedFunction()
    {
        resetSelectionFalse();
        characterSelected[0] = true;
     

    }
    public void fatManSelectedFunction()
    {
        resetSelectionFalse();
        characterSelected[1] = true;
       

    }
    public void guySelectedFunction()
    {
        resetSelectionFalse();
        characterSelected[2] = true;
       

    }
    public void drunkManSelectedFunction()
    {
        resetSelectionFalse();
        characterSelected[3] = true;
        

    }
    public void chickenSelectedFunction()
    {
        resetSelectionFalse();
        characterSelected[4] = true;
       

    }
    public void oldManSelectedFunction()
    {
        resetSelectionFalse();
        characterSelected[5] = true;
        

    }

    public void spawnCharacter()
    {
        for (int i = 0; i < 6; i++)
        {
            if (characterSelected[i] == true )
            {
                Vector3 mousePosition = Input.mousePosition;
                // Convert the mouse position to world position
                mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
               
                GameObject character = Instantiate(charactersPrefabs[i], mousePosition, Quaternion.identity);
                characterList.Add(character);
                character.GetComponent<Character>().SetList(characterList);
                resetSelectionFalse();

                GameObject playerManagerObject = GameObject.Find("PlayerManager");
                PlayerManager playerManager = playerManagerObject.GetComponent<PlayerManager>();

                playerManager.decreasePlayerMoney(i);

                


            }
        }
    }


    //function to reset all the buttons selected to false
    private void resetSelectionFalse()
    {
        for (int i = 0; i < 6; i++)
        {
            characterSelected[i] = false;
        }
    }

   
    
}
