using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public TextMeshPro ScoreText;
    public Image ProgressIndicator;

    private float score = 0f;
    private float activeScore = 0f;
    private float targetScore = 5f;

    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
        activeScore = 0f;
        targetScore = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncrementScore();
        }
    }

    void IncrementScore()
    {
        // Update score text
        score += 1f;
        ScoreText.text = score.ToString();

        // Update radial progress indicator
        IncrementTargetScore();
        ProgressIndicator.fillAmount = (1f / targetScore) * activeScore;
    }

    void IncrementTargetScore()
    {
        // Increment target score progress
        activeScore += 1;

        // Configure achievement goals here
        switch (activeScore)
        {
            case 5f:
                activeScore = 0;
                targetScore = 10f;
                break;
            case 15f:
                activeScore = 0;
                targetScore = 15f;
                break;
            case 30f:
                activeScore = 0;
                targetScore = 20f;
                break;
            case 50f:
                activeScore = 0;
                targetScore = 25f;
                break;
            case 75f:
                activeScore = 0;
                targetScore = -1;
                break;
            default:
                break;
        }
    }

}
