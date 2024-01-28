using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public List<Tuple<string, GameObject>> jkList = new List<Tuple<string, GameObject>>();
    [SerializeField] private int jokePoints = 0;
    public void AddPoints(string action, GameObject origin, int points)
    {
        if (searchJKList(action, origin) == false){
            jokePoints += points;
            jkList.Add(Tuple.Create(action, origin));
        }
    }
    private bool searchJKList(string action, GameObject origin)
    {
        bool result = false;
        foreach (Tuple<string, GameObject> jk in jkList)
        {
            if (jk.Item1 == action && jk.Item2 == origin)
            {
                result = true;
            }
        }

        return result;
    }
    public int GetJokePoints()
    {
        return jokePoints;
    }

    private int playerMoney = 1000;
    public TextMeshProUGUI playerMoneyDisplay;

    //preço que cada character custa
    [SerializeField] private int[] charactersMoney = new int[6];

    //botoes das characters
    [SerializeField] private Button[] buttons = new Button[6];


    // Start is called before the first frame update
    void Start()
    {
        charactersMoney[0] = 10;
        charactersMoney[1] = 20;
        charactersMoney[2] = 30;
        charactersMoney[3] = 40;
        charactersMoney[4] = 50;
        charactersMoney[5] = 60;

   
    }

    // Update is called once per frame
    void Update()
    {
        playerMoneyDisplay.text = "Giggles: " + playerMoney.ToString();

        if (playerMoney <= 0)
        {
            playerMoney = 0;
        }

        //se o character custar mais dinheiro que o player tem , desativa esse botao
        for (int i = 0; i < 6; i++)
        {
            if (charactersMoney[i] > playerMoney)
            {
                buttons[i].interactable = false;
            }
        }
    }

     public void decreasePlayerMoney(int characterNumber)
    {
        if(playerMoney > 0)
        {
            playerMoney -= charactersMoney[characterNumber];
            Debug.Log(playerMoney);

        }
    
    }
}
