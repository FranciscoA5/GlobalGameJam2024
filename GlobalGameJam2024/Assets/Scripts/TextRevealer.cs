using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextRevealer : MonoBehaviour
{
    [HideInInspector] public TextMeshProUGUI textMesh;
    public float revealSpeed = 0.1f; // Adjust the speed at which each word is revealed
    public float initialPause = 0;

    private string[] words;
    private string originalText;

    void Start()
    {
        // Get the TextMeshPro component if not assigned
        if (textMesh == null)
            textMesh = GetComponent<TextMeshProUGUI>();

        // Split the original text into words
        originalText = textMesh.text;
        words = originalText.Split(' ');

        // Start revealing words
        StartCoroutine(RevealWords());
    }

    private System.Collections.IEnumerator RevealWords()
    {
        // Reset text to empty
        textMesh.text = "";

        yield return new WaitForSeconds(initialPause);

        // Iterate through each word and reveal them one by one
        for (int i = 0; i < words.Length; i++)
        {
            // Append the next word
            textMesh.text += words[i];

            // Wait for a short duration before revealing the next word
            yield return new WaitForSeconds(revealSpeed);

            // Add space between words (except for the last word)
            if (i < words.Length - 1)
                textMesh.text += " ";
        }
    }

    // This method can be used to reset the text
    public void ResetText()
    {
        StopAllCoroutines();
        textMesh.text = originalText;
        StartCoroutine(RevealWords());
    }
}
