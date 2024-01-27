using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
   public void StartButton()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void Settings()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
