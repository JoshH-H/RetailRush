using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    [SerializeField] public bool isCorrect = false;
    [SerializeField] QuestionManager questionManager;

    [Header("AudioResponses")]
    [SerializeField] AudioSource correctSound;
    [SerializeField] AudioSource wrongSound;

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
