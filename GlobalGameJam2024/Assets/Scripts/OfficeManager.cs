using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OfficeManager : MonoBehaviour
{
    [SerializeField] private GameObject clickAnything;
    [SerializeField] private GameObject clown1Balloon;
    [SerializeField] private GameObject clown2Balloon;
    [SerializeField] private GameObject makeMeLaugh;
    [SerializeField] private GameObject balloonText;

    int counter = 0;

    private void Start()
    {
        if (counter == 0)
        {
            clickAnything.SetActive(true);
            clown2Balloon.SetActive(false);
            makeMeLaugh.SetActive(false);
            clown1Balloon.SetActive(false);
            balloonText.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (counter == 0)
            {
                clickAnything.SetActive(false);
                clown2Balloon.SetActive(true);
                makeMeLaugh.SetActive(true);
                counter++;
            }
            else if (counter == 1)
            {
                clown2Balloon.SetActive(false);
                makeMeLaugh.SetActive(false);
                clown1Balloon.SetActive(true);
                balloonText.transform.position = clown1Balloon.transform.position;
                balloonText.GetComponent<TextMeshProUGUI>().text = "Then how about a joke...?";
                balloonText.SetActive(true);
                counter++;
            }
            else if (counter == 3)
            {
                SceneManager.LoadScene("Duarte");
            }
        }
    }
}
