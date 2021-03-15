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

}