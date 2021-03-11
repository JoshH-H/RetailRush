using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    [Header("Customize Questions")]
    [SerializeField] public List<QnA> QuestionsNAnswers;
    [SerializeField] public GameObject[] options;
    [SerializeField] public int currentQuestion;

    [Header("Link Question Text")]
    [SerializeField] public Text QuestionTxt;

    [Header("Question Help")]
    [SerializeField] GameObject notification;

    [Header("Pannel UI")]
    [SerializeField] GameObject pannelUI;
    [SerializeField] Text countdownText;
    //[SerializeField] AnswerScript[] answerScript;
    private Coroutine currentRoutine;
    static float countdownTime;
    static public float option;
    public GameObject answerPannelsTL;
    public GameObject answerPannelsTR;
    public GameObject answerPannelsBL;
    public GameObject answerPannelsBR;

    [Header("Other Script Connections")]
    [SerializeField] private float setTimer;

    [Header("Evaldas Char")]
    [SerializeField] PathController pathController;



    private void Start()
    {
        pannelUI.SetActive(true);
        generateQuestion();
        answerPannelsTL.SetActive(false);
        answerPannelsTR.SetActive(false);
        answerPannelsBL.SetActive(false);
        answerPannelsBR.SetActive(false);
        UIManager.instance.pauseButton.interactable = false;
    }

    void Awake()
    {
        setTimer = PlayerPrefs.GetFloat("_timing");
        Debug.Log("Timer is set to" + setTimer);
    }

    public void correct()
    {
        QuestionsNAnswers.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        answerPannelsTL.SetActive(true);
        answerPannelsTR.SetActive(true);
        answerPannelsBL.SetActive(true);
        answerPannelsBR.SetActive(true);
        currentRoutine = StartCoroutine(CountdownStart());
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QuestionsNAnswers[currentQuestion].Answers[i];

            if (QuestionsNAnswers[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
            if (QuestionsNAnswers[currentQuestion].confusedAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isConfused = true;
            }
        }
    }

    void generateQuestion()
    {
        StartCoroutine(newAlert());
        Invoke("SetAnswers", 4);

        if (QuestionsNAnswers.Count > 0)
        {
            if (currentRoutine != null)
            {
                StopCoroutine(currentRoutine);
            }
            QuestionTxt.text = QuestionsNAnswers[currentQuestion].Question;
        }
        else
        {
            
            Debug.Log("Complete");
            pannelUI.SetActive(false);
            UIManager.instance.pauseButton.interactable = true;
            pathController.DoneTalking = true;
            if (currentRoutine != null)
            {
                StopCoroutine(currentRoutine);
            }
        }

    }

    IEnumerator newAlert()
    {
        notification.SetActive(true);

        yield return new WaitForSeconds(3);

        notification.SetActive(false);
    }

    IEnumerator CountdownStart()
    {
        countdownTime = setTimer;

        while (countdownTime >= 0)
        {
            countdownText.text = countdownTime.ToString("0");
            countdownTime -= Time.deltaTime;
            yield return null;
        }

        answerPannelsTL.SetActive(false);
        answerPannelsTR.SetActive(false);
        answerPannelsBL.SetActive(false);
        answerPannelsBR.SetActive(false);
        correct();
    }

}