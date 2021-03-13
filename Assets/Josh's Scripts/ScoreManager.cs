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

    private void Awake()
    {
        playerScore = 0;
        instance = this;
    }
    private void Update()
    {
        currentProgress();

        Debug.Log("Score " + playerScore);
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

/*    public void ConfusedScore()
    {
        playerScore += 10;
    }*/
    //Scoring End

    public void progressReport()
    {

        if (playerScore <= 10)
        {
            Debug.Log("OK Score");
        }

        if (playerScore > 11 && playerScore <= 20)
        {
            Debug.Log("Decent Score");
        }

        if (playerScore > 21 && playerScore <= 30)
        {
            Debug.Log("Alright Score");
        }

        if (playerScore > 31 && playerScore <= 40)
        {
            Debug.Log("Nice Score");
        }
    }

}