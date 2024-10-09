using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager3 : MonoBehaviour
{
    public List<QuestionsAndAnswers2> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public TMP_Text QuestionTxt;
    public GameObject qcanvas;
    static public int qcount = 0;
    private bool inQ = false;
    static public string interaction = "null";
    public DemonScript demon;
    public MovingSpikes moovingSpikes;
    public PlayerController player;
    public DemonBScript demonb;

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
            if (interaction == "demon")
            {
                player.attack();
                demon.rightAnswer();
            }
            if (interaction == "demonb")
            {
                player.attack();
                demonb.rightAnswer();
            }
        }
        else //Here the player wins current opponent
        {
            qcanvas.SetActive(false);
            inQ = false;
            if (interaction == "demon")
            {
                player.attack();
                demon.beaten();
            }
            if (interaction == "trapl3")
            {
                moovingSpikes.StartMoving();
            }
            if (interaction == "demonb")
            {
                player.attack();
                demonb.beaten();
            }

        }
    }

    public void wrong()
    {
        PlayerController.score = PlayerController.score - 10;
        Debug.Log(interaction);
        if (qcount > 0)         //Here the player gets a wrong answer and gets damaged
        {
            if (interaction == "demon")
            {
                demon.wrongAnswer();
                player.takeDamage();
            }
            if (interaction == "trapl3")
            {
                PlayerController.health--;
            }
            if (interaction == "demonb")
            {
                demonb.wrongAnswer();
                player.takeDamage();
            }
            generateQuestion();

        }
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript3>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript3>().isCorrect = true;
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
