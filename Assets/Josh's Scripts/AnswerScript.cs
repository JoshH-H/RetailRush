using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    [SerializeField] public bool isCorrect = false;
    [SerializeField] public bool isConfused = false;
    [SerializeField] QuestionManager questionManager;
    //[SerializeField] ScoreManager scoreManager;
    private int scoreCorrectValue = 15;
    private int scoreWrongValue = 5;
    private int scoreConfusedValue =10;
    private int globalScore;

    [Header("AudioResponses")]
    [SerializeField] AudioSource correctSound;
    [SerializeField] AudioSource wrongSound;

    [Header("Emotional Responses")]
    [SerializeField] GameObject happyResponse;
    [SerializeField] GameObject unhappyResponse;
    [SerializeField] GameObject confusedResponse;
    [SerializeField] GameObject head;

    private Renderer getAngry;

    private void Start() 
    { 
        getAngry = head.GetComponent<Renderer>();
        getAngry.material.SetFloat("_Angry", 0f);
        globalScore = 0;
    }

    public void Answer()
    {
        if (isCorrect)
        {
            globalScore += scoreCorrectValue;
            PlayerPrefs.SetInt("_score", globalScore + 15);
            Debug.Log("That's right");
            questionManager.correct();
            questionManager.answerPannelsTL.SetActive(false);
            questionManager.answerPannelsTR.SetActive(false);
            questionManager.answerPannelsBL.SetActive(false);
            questionManager.answerPannelsBR.SetActive(false);
            getAngry.material.SetFloat("_Angry", 0f);
            correctSound.Play();
            
            Debug.Log("score " + globalScore);
        }
        else
        {
            PlayerPrefs.SetInt("_score", globalScore - scoreWrongValue);
            Debug.Log("That's wrong");
            questionManager.correct();
            questionManager.answerPannelsTL.SetActive(false);
            questionManager.answerPannelsTR.SetActive(false);
            questionManager.answerPannelsBL.SetActive(false);
            questionManager.answerPannelsBR.SetActive(false);
            wrongSound.Play();
            happyResponse.SetActive(false);
            unhappyResponse.SetActive(true);
            getAngry.material.SetFloat("_Angry", 1f);
            Invoke("response", 2);
            
            Debug.Log("score " + globalScore);
        }
        if (isConfused)
        {
            PlayerPrefs.SetInt("_score", globalScore + scoreConfusedValue);
            questionManager.correct();
            questionManager.answerPannelsTL.SetActive(false);
            questionManager.answerPannelsTR.SetActive(false);
            questionManager.answerPannelsBL.SetActive(false);
            questionManager.answerPannelsBR.SetActive(false);
            wrongSound.Play();
            happyResponse.SetActive(false);
            confusedResponse.SetActive(true);
            Invoke("confusedAnswer", 2);
            getAngry.material.SetFloat("_Angry", 0f);

            Debug.Log("score " + globalScore);
        }

    }

    public void response()
    {
        happyResponse.SetActive(true);
        unhappyResponse.SetActive(false);
    }

    public void confusedAnswer()
    {
        happyResponse.SetActive(true);
        confusedResponse.SetActive(false);
    }
}
