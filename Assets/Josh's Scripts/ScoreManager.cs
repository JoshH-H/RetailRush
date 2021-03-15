using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ScoreManager : MonoBehaviour
{
    [SerializeField] int playerScore;
    public static ScoreManager instance;
    public int maximum;
    public Image mask;
    [SerializeField] GameObject nextShift;

    [SerializeField] string[] results;
    [SerializeField] Text resultText;

    private void Awake()
    {
        playerScore = 0;
        instance = this;
    }
    private void Update()
    {
        currentProgress();

        Debug.Log("Score " + playerScore);

        if (playerScore <= 0)
        {
            playerScore = 0;
        }

        if (playerScore >= maximum)
        {
            playerScore = maximum;
        }

        ResultTexts();
    }


    public void currentProgress()
    {
        float fillAmount = (float)playerScore / (float)maximum;
        mask.fillAmount = fillAmount;
    }

    //Scoring
    public void RightScore()
    {
        playerScore += 10;
    }

    public void WrongScore()
    {
        playerScore -= 10;
    }
    //Scoring End

    public void progressReport()
    {
        if (playerScore >= 40)
        {
            nextShift.SetActive(true);
            Debug.Log("too good");
        }
        else
        {
            nextShift.SetActive(false);
            Debug.Log("too bad");
        }
    }

    public void progressReportManager()
    {
        if (playerScore >=230)
        {
            nextShift.SetActive(true);
            Debug.Log("too good");
        }
        else
        {
            nextShift.SetActive(false);
            Debug.Log("too bad");
        }
    }

    private void ResultTexts()
    {
        if (playerScore < 250)
        {
            string goodResult = results[0];
            resultText.text = goodResult.ToString();
        }

        if (playerScore <= 249 && playerScore > 200)
        {
            string okResult = results[1];
            resultText.text = okResult.ToString();
        }

        if (playerScore <= 199 && playerScore > 100)
        {
            string badResult = results[2];
            resultText.text = badResult.ToString();
        }

        if (playerScore <= 99)
        {
            string worstResult = results[3];
            resultText.text = worstResult.ToString();
        }
    }

}