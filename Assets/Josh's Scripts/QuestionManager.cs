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

    [Header("Pannel UI")]
    [SerializeField] GameObject pannelUI;
    [SerializeField] Text countdownText;
    float currentTime = 0f;
    float startingTime = 10f;

    public void Start()
    {
        currentTime = startingTime;

        generateQuestion();

    }

    public void correct()
    {
        QuestionsNAnswers.RemoveAt(currentQuestion);
        generateQuestion();
        //beginTimer();
    }

    void SetAnswers()
    {
        for(int i = 0; i< options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QuestionsNAnswers[currentQuestion].Answers[i];

            if(QuestionsNAnswers[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QuestionsNAnswers.Count > 0) 
        {
            

            //currentQuestion =Random.Range (0, QuestionsNAnswers.Count);

            QuestionTxt.text = QuestionsNAnswers[currentQuestion].Question;
            SetAnswers();
            
        }
        else
        {
            Debug.Log("Complete");
            pannelUI.SetActive(false);
        }

    }

/*    void beginTimer()
    {
        startingTime = 10f;
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            //GetComponent<AnswerScript>().isCorrect = false;
            correct();
        }
    }*/
    void Update()
    {
        startingTime = 10f;
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            //GetComponent<AnswerScript>().isCorrect = false;
            correct();
        }
    }
}