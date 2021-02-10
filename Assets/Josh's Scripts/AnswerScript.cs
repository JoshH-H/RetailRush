using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    [SerializeField] public bool isCorrect = false;
    [SerializeField] QuestionManager questionManager;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("That's right");
            questionManager.correct();
        }
        else
        {
            Debug.Log("That's wrong");
            questionManager.correct();
        }
    }
}
