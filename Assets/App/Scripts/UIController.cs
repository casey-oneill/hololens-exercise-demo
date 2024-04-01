using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public TextMeshPro MotivationText;
    public TextMeshPro ScoreText;
    public GameObject ProgressIndicator;
    public GameObject[] StarIndicators;

    private ProgessIndicatorController progessIndicatorController;

    private float score = 0f;
    private float activeScore = 0f;
    private float targetScore = 5f;

    private int starCount = 0;
    private int motivationCount = 0;

    private string[] motivations =
    {
        "You can do this!",
        "You're breezing through this!",
        "You've got this!",
        "Keep this up!",
        "See how far you can go!",
        "You're doing great!",
        "You're stronger than you think!",
        "Push through the burn, it's worth it!",
        "Keep moving forward!",
        "Embrace the challenge, it will make you stronger!",
        "Your body can do amazing things, keep pushing!",
        "One more rep, you can do it!",
        "Every effort counts!",
        "Keep going!",
        "Your body achieves what your mind believes!",
        "Trust in your progress!",
        "Your body is thanking you for taking care of it!",
        "Focus on the process, and results will follow!",
        "You're rewriting your limits with every rep!",
        "Every rep brings you closer to your goals!",
        "Your effort today is your reward tomorrow!",
        "Challenges are opportunities to prove yourself stronger!",
        "Let your determination shine!",
        "Keep moving forward, even if it's one rep at a time!",
        "Your work today is amazing!"
    };

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
    
        starCount = 0;
        motivationCount = 0;

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
        score++;
        ScoreText.text = score.ToString() + "\nReps";

        // Update radial progress indicator
        IncrementTargetScore();
        progessIndicatorController.SetIndicatorValue(360f - (360f / targetScore) * activeScore);

        // Update motivational text
        ShowMotivation();
    }

    void IncrementTargetScore()
    {
        // Increment target score progress
        activeScore += 1;

        // Configure achievement goals here
        if (starCount == 0 && activeScore == targetScore)
        {
            activeScore = 0;
            targetScore = 10f;

            ShowStar(0);
        } else if (starCount == 1 && activeScore == targetScore)
        {
            activeScore = 0;
            targetScore = 10f;

            ShowStar(1);
        }
        else if (starCount == 2 && activeScore == targetScore)
        {
            activeScore = 0;
            targetScore = 10;

            ShowStar(2);
        }
        else if (starCount == 3 && activeScore == targetScore)
        {
            activeScore = 0;
            targetScore = 15f;

            ShowStar(3);
        }
        else if (starCount == 4 && activeScore == targetScore)
        {
            // Max level reached, progress indicator should remain filled
            activeScore = 1;
            targetScore = 1;

            ShowStar(4);
        }
    }

    void ShowStar(int index)
    {
        starCount++;
        StarIndicators[index].SetActive(true); // ToDo: Polish
    }

    void ShowMotivation()
    {
        if (score % 2 == 0)
        {
            motivationCount++;
            MotivationText.text = motivations[motivationCount - 1];
        }
    }

}
