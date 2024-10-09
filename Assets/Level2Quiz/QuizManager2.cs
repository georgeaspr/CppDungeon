using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager2 : MonoBehaviour
{
    public List<QuestionsAndAnswers2> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public TMP_Text QuestionTxt;
    public GameObject qcanvas;
    static public int qcount = 0;
    private bool inQ = false;
    static public string interaction = "null";
    public GoblinScript goblin;
    public Level2Trap trap;
    public PlayerController player;
    public BODScript BOD;

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
            if (interaction == "goblin")
            {
                player.attack();
                goblin.rightAnswer();
            }
            if (interaction == "BOD")
            {
                player.attack();
                BOD.rightAnswer();
            }
        }
        else //Here the player wins current opponent
        {
            qcanvas.SetActive(false);
            inQ = false;
            if (interaction == "goblin")
            {
                player.attack();
                goblin.beaten();
            }
            if (interaction == "trap")
            {
                trap.rightAnswer();
            }
            if (interaction == "BOD")
            {
                player.attack();
                BOD.beaten();
            }

        }
    }

    public void wrong()
    {
        PlayerController.score = PlayerController.score - 10;
        Debug.Log(interaction);
        if (qcount > 0)         //Here the player gets a wrong answer and gets damaged
        {
            if (interaction == "goblin")
            {
                goblin.wrongAnswer();
                player.takeDamage();
            }
            if (interaction == "trap")
            {
                trap.wrongAnswer();
            }
            if (interaction == "BOD")
            {
                BOD.wrongAnswer();
                player.takeDamage();
            }
            generateQuestion();

        }
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript2>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript2>().isCorrect = true;
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
