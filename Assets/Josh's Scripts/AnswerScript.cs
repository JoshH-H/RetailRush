using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    [Header("Bools and Connections")]
    [SerializeField] public bool isCorrect = false;
    [SerializeField] public bool isConfused = false;
    [SerializeField] QuestionManager questionManager;

    [Header("AudioResponses")]
    [SerializeField] AudioSource correctSound;
    [SerializeField] AudioSource wrongSound;
    [SerializeField] AudioSource confusedSound;

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
            ScoreManager.instance.RightScore();
            Debug.Log("That's right");
            questionManager.correct();
            questionManager.answerPannelsTL.SetActive(false);
            questionManager.answerPannelsTR.SetActive(false);
            questionManager.answerPannelsBL.SetActive(false);
            questionManager.answerPannelsBR.SetActive(false);
            getAngry.material.SetFloat("_Angry", 0f);
            correctSound.Play();
        }

        if (isConfused)
        {
            ScoreManager.instance.ConfusedScore();
            questionManager.correct();
            questionManager.answerPannelsTL.SetActive(false);
            questionManager.answerPannelsTR.SetActive(false);
            questionManager.answerPannelsBL.SetActive(false);
            questionManager.answerPannelsBR.SetActive(false);
            confusedSound.Play();
            happyResponse.SetActive(false);
            confusedResponse.SetActive(true);
            Invoke("confusedAnswer", 2);
            getAngry.material.SetFloat("_Angry", 0f);
        }

        else 
        {
            ScoreManager.instance.WrongScore();
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

    }

    public void response()
    {
        happyResponse.SetActive(true);
        unhappyResponse.SetActive(false);
        getAngry.material.SetFloat("_Angry", 0f);
    }

    public void confusedAnswer()
    {
        happyResponse.SetActive(true);
        confusedResponse.SetActive(false);
        getAngry.material.SetFloat("_Angry", 0f);
    }
}
