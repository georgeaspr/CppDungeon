using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BODScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject BOD;

    private bool playerInRange; // Flag to track if the player is in range of the door
    private bool alive = true;
    private Rigidbody2D playerRigidbody; // Reference to the player's Rigidbody
    public AudioSource attack;

    private void Start()
    {
        // Get the player's Rigidbody component
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && alive)
        {
            playerInRange = true;

        }
    }

    private void Update()
    {
        if (playerInRange)
        {
            PlayerController.canMove = false;
            canvas.SetActive(true);
            QuizManager2.interaction = "BOD";
            QuizManager2.qcount = QuizManager2.qcount + 5;
            playerInRange = false;
        }
    }

    public void rightAnswer()
    {
        BOD.GetComponent<Animator>().Play("TakeHitBOD");
    }

    public void wrongAnswer()
    {
        BOD.GetComponent<Animator>().Play("AttackBOD");
        attack.Play();
    }

    public void beaten()
    {
        BOD.GetComponent<Animator>().Play("DeathBOD");
        PlayerController.canMove = true;
        alive = false;
    }
}
