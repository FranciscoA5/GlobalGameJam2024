using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private int playerMoney = 1000;
    public TextMeshProUGUI playerMoneyDisplay;

    //pre�o que cada character custa
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
