using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ScoreManager : MonoBehaviour
{
    public int playerScore;
    //public Text playerScrTxt;
    public int maximum;
    public Image mask;
    public GameObject scoreSystem;

    private void Awake()
    {
        playerScore = 0;
        scoreSystem.SetActive(false);
        playerScore = PlayerPrefs.GetInt("_score");
    }
    private void Update()
    {
        currentProgress();
    }

    public void currentProgress()
    {
        float fillAmount = (float)playerScore / (float)maximum;
        mask.fillAmount = fillAmount;
    }

    public void SetScore()
    {
       // playerScrTxt.text = playerScore.ToString();
    }

    public void progressReport()
    {
        scoreSystem.SetActive(true);

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