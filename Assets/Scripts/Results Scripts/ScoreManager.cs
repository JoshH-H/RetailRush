using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ScoreManager : MonoBehaviour
{
    [SerializeField] public int playerScore;
    public static ScoreManager instance;
    public static int maximum = 200;
    public Image mask;
    [SerializeField] GameObject nextShift;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject failMenu;

    public static int[] Scores = { 210, 209, 170, 169, 150, 149, 90, 89 };
    public static int minimum = 150;

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

        //Debug.Log("Score " + playerScore);

        if (playerScore <= 0)
        {
            playerScore = 0;
        }

        if (playerScore >= maximum)
        {
            playerScore = maximum;
        }

        ResultTexts();
        print(Scores[0] + " " + Scores[1] + " " + " " + Scores[2] + " " + Scores[3] + " " + Scores[4] + " " + Scores[5] + " " + Scores[6] + " " + Scores[7]);
        
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
        if (playerScore >= minimum)
        {
            nextShift.SetActive(true);
            winMenu.SetActive(true);
            failMenu.SetActive(false);
            Debug.Log("too good");
        }
        else
        {
            nextShift.SetActive(false);
            winMenu.SetActive(false);
            failMenu.SetActive(true);
            Debug.Log("too bad");
        }
    }

    private void ResultTexts()
    {
        if (playerScore >= Scores[0])
        {
            string goodResult = results[0];
            resultText.text = goodResult.ToString();
        }

        if (playerScore <= Scores[1] && playerScore >= Scores[2])
        {
            string okResult = results[1];
            resultText.text = okResult.ToString();
        }

        if (playerScore <= Scores[3] && playerScore >= Scores[4])
        {
            string badResult = results[2];
            resultText.text = badResult.ToString();
        }

        if (playerScore <= Scores[5] && playerScore >= Scores[6])
        {
            string worstResult = results[3];
            resultText.text = worstResult.ToString();
        }

        if (playerScore <= Scores[7])
        {
            string theWorstResult = results[4];
            resultText.text = theWorstResult.ToString();
        }
    }

}