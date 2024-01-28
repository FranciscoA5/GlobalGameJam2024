using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextHighlight : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float scaleSpeed = 0.5f;
    public float maxScale = 2f;
    public float minScale = 1f;

    private float currentScale = 1f;
    private bool scalingUp = true;

    void Start()
    {
        // Get the TextMeshPro component if not assigned
        if (textMesh == null)
            textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Scale the text up and down continuously
        if (scalingUp)
        {
            currentScale += scaleSpeed * Time.deltaTime;
            if (currentScale >= maxScale)
                scalingUp = false;
        }
        else
        {
            currentScale -= scaleSpeed * Time.deltaTime;
            if (currentScale <= minScale)
                scalingUp = true;
        }

        // Apply the scale to the text
        textMesh.transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }
}
