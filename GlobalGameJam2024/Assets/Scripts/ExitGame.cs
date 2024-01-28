using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    // Attach this script to the Button GameObject

    void Start()
    {
        // Get the Button component
        Button closeButton = GetComponent<Button>();

        // Add a listener to call the function when the button is clicked
        closeButton.onClick.AddListener(CloseGame);
    }

    // Function to close the game
    public void CloseGame()
    {
       
            Application.Quit();
 
    }
}
