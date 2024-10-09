using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Trap : MonoBehaviour
{

    public GameObject trapFloor;
    public GameObject moovingdoors;
    private bool trapactive = true;
    private bool playerInRange = false;
    public GameObject canvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && trapactive)
        {
            trapactive = false;
            playerInRange = true;
            moovingdoors.transform.Translate(0f, -2.60f, 0f);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        trapactive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            playerInRange = false;
            canvas.SetActive(true);
            QuizManager2.interaction = "trap";
            QuizManager2.qcount = QuizManager2.qcount + 1;
        }
    }

    public void rightAnswer()
    {
        moovingdoors.transform.Translate(0f, 2.60f, 0f);
    }

    public void wrongAnswer()
    {
        canvas.SetActive(false);
        trapFloor.SetActive(false);
    }
}
