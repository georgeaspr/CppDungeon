using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject goblin;

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
            QuizManager2.interaction = "goblin";
            QuizManager2.qcount = QuizManager2.qcount + 3;
            playerInRange = false;
        }
    }

    public void rightAnswer()
    {
        goblin.GetComponent<Animator>().Play("TakeHitGoblin");
    }

    public void wrongAnswer()
    {
        goblin.GetComponent<Animator>().Play("AttackGoblin");
        attack.Play();
    }

    public void beaten()
    {
        goblin.GetComponent<Animator>().Play("DeathGoblin");
        PlayerController.canMove = true;
        alive = false;
    }
}
