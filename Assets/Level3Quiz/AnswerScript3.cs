using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript3 : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager3 quizManager3;

    public void Answer()
    {
        if (isCorrect)
        {
            QuizManager3.qcount--;
            Debug.Log("Correct");
            quizManager3.correct();
        }
        else
        {
            Debug.Log("Wrong");
            quizManager3.wrong();
        }
    }
}
