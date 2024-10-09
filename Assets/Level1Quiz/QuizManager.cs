using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public TMP_Text QuestionTxt;
    public GameObject qcanvas;
    static public int qcount = 0;
    private bool inQ = false;
    static public string interaction = "null";
    public Lever lever;
    public SkeletonScript skeleton;
    public PlayerController player;
    public Spikes spikes;

    private void Start()
    {
        //generateQuestion();
        qcount = 0;
    }

    public void correct()
    {
        PlayerController.score = PlayerController.score + 10;
        QnA.RemoveAt(currentQuestion);
        if (qcount > 0)     //Here the player gets a correct answer and hits the opponent
        {
            generateQuestion();
            if (interaction == "skeleton")
            {
                player.attack();
                skeleton.rightAnswer();
            }
        }
        else //Here the player wins current opponent
        {
            qcanvas.SetActive(false);
            inQ = false;
            if (interaction == "lever")
            {
                lever.rightAnswer();
            }
            if (interaction == "skeleton")
            {
                player.attack();
                skeleton.beaten();
            }
            if (interaction == "spikes")
            {
                spikes.goBack();
            }

        }
    }

    public void wrong()
    {
        PlayerController.score = PlayerController.score - 10;
        Debug.Log(interaction);
        if (qcount > 0)         //Here the player gets a wrong answer and gets damaged
        {
            if (interaction == "lever")
            {
                lever.wrongAnswer();
            }
            if (interaction == "skeleton")
            {
                skeleton.wrongAnswer();
                player.takeDamage();
            }
            generateQuestion();
        }
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            qcanvas.SetActive(false);
            Debug.Log("Out of Questions");
        }


    }

    void Update()
    {
        if (qcount > 0 && inQ == false) 
        {
            inQ = true;
            generateQuestion();
        }
    }
}
