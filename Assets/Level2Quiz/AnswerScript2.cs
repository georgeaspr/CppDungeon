using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript2 : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager2 quizManager2;

    public void Answer()
    {
        if (isCorrect)
        {
            QuizManager2.qcount--;
            Debug.Log("Correct");
            quizManager2.correct();
        }
        else
        {
            Debug.Log("Wrong");
            quizManager2.wrong();
        }
    }
}
