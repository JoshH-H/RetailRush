using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    [SerializeField] public bool isCorrect = false;
    [SerializeField] public bool isConfused = false;
    [SerializeField] QuestionManager questionManager;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] int scoreCorrectValue;
    [SerializeField] int scoreWrongValue;

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
    }

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("That's right");
            questionManager.correct();
            questionManager.answerPannelsTL.SetActive(false);
            questionManager.answerPannelsTR.SetActive(false);
            questionManager.answerPannelsBL.SetActive(false);
            questionManager.answerPannelsBR.SetActive(false);
            getAngry.material.SetFloat("_Angry", 0f);
            correctSound.Play();

        }
        else
        {
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
        }
        if (isConfused)
        {
            questionManager.correct();
            questionManager.answerPannelsTL.SetActive(false);
            questionManager.answerPannelsTR.SetActive(false);
            questionManager.answerPannelsBL.SetActive(false);
            questionManager.answerPannelsBR.SetActive(false);
            wrongSound.Play();
            happyResponse.SetActive(false);
            confusedResponse.SetActive(true);
            Invoke("confusedAsnwer", 2);
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
