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
    [SerializeField] private GameObject clown1faceGood;
    [SerializeField] private GameObject clown2faceGood;
    [SerializeField] private GameObject clown1faceBad;
    [SerializeField] private GameObject clown2faceBad;

    int counter;

    private void Start()
    {
        counter = MeetingData.counterValue;

        clown1faceGood.SetActive(false);
        clown1faceBad.SetActive(true);
        clown2faceGood.SetActive(false);
        clown2faceBad.SetActive(true);

        if (counter == 0)
        {
            clickAnything.SetActive(true);
            clown2Balloon.SetActive(false);
            makeMeLaugh.SetActive(false);
            clown1Balloon.SetActive(false);
            balloonText.SetActive(false);
        }

        if (counter == 3)
        {
            clickAnything.SetActive(false);
            clown2Balloon.SetActive(true);
            makeMeLaugh.SetActive(false);
            clown1Balloon.SetActive(false);
            balloonText.GetComponent<TextMeshProUGUI>().text = "Do you really think that's funny?";
            balloonText.transform.position = clown2Balloon.transform.position;
            balloonText.SetActive(true);
            counter++;
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
            else if (counter == 2)
            {
                SceneManager.LoadScene("Duarte");
            }
            else if (counter == 4)
            {
                if (MeetingData.finalJokePoints >= 30)
                {
                    clown1faceGood.SetActive(true);
                    clown1faceBad.SetActive(false);
                    clown2faceGood.SetActive(true);
                    clown2faceBad.SetActive(false);

                    balloonText.SetActive(false);
                    balloonText.GetComponent<TextMeshProUGUI>().text = "Because it is hilarious! You're hired!";
                    balloonText.SetActive(true);
                }
                else if (MeetingData.finalJokePoints < 30)
                {
                    balloonText.SetActive(false);
                    balloonText.GetComponent<TextMeshProUGUI>().text = "I think you should reevaluate your comedy, sir,";
                    balloonText.SetActive(true);
                }

                counter++;
            }
            else if (counter == 5)
            {
                SceneManager.LoadScene("Ending");
            }
        }
    }
}
