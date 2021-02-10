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

    private void Start()
    {
        generateQuestion();
 
    }

    public void correct()
    {
        QuestionsNAnswers.RemoveAt(currentQuestion);
        generateQuestion();
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
        if(QuestionsNAnswers.Count > 0) 
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
}
