using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public TextMeshPro ScoreText;
    public GameObject ProgressIndicator;
    public GameObject[] StarIndicators;

    private ProgessIndicatorController progessIndicatorController;

    private float score = 0f;
    private float activeScore = 0f;
    private float targetScore = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize UI components
        progessIndicatorController = ProgressIndicator.GetComponent<ProgessIndicatorController>();

        foreach (GameObject image in StarIndicators)
        {
            image.SetActive(false);
        }

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
        ScoreText.text = score.ToString() + "\nReps";

        // Update radial progress indicator
        IncrementTargetScore();
        progessIndicatorController.SetIndicatorValue(360f - (360f / targetScore) * activeScore);
    }

    void IncrementTargetScore()
    {
        // Increment target score progress
        activeScore += 1;

        // Configure achievement goals here
        if (activeScore == targetScore && targetScore == 5f)
        {
            activeScore = 0;
            targetScore = 10f;

            ShowStar(0);
        } else if (activeScore == targetScore && targetScore == 10f)
        {
            activeScore = 0;
            targetScore = 15f;

            ShowStar(1);
        }
        else if (activeScore == targetScore && targetScore == 15f)
        {
            activeScore = 0;
            targetScore = 20f;

            ShowStar(2);
        }
        else if (activeScore == targetScore && targetScore == 20f)
        {
            activeScore = 0;
            targetScore = 25f;

            ShowStar(3);
        }
        else if (activeScore == targetScore && targetScore == 25f)
        {
            // Max level reached, progress indicator should remain filled
            activeScore = 1;
            targetScore = 1;

            ShowStar(4);
        }
    }

    void ShowStar(int index)
    {
        StarIndicators[index].SetActive(true); // ToDo: Polish
    }

}
