using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject demon;

    private bool playerInRange; // Flag to track if the player is in range of the door
    private bool alive = true;
    private Rigidbody2D playerRigidbody; // Reference to the player's Rigidbody
    private int i;
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
            QuizManager3.interaction = "demon";
            QuizManager3.qcount = QuizManager3.qcount + 4;
            playerInRange = false;
        }
    }

    public void rightAnswer()
    {
        demon.GetComponent<Animator>().Play("DemonTakeHit");
    }

    public void wrongAnswer()
    {
        i = Random.Range(1, 3);

        if (i == 1)
        {
            demon.GetComponent<Animator>().Play("DemonAttack");
        }
        else if (i == 2)
        {
            demon.GetComponent<Animator>().Play("DemonAttack2");
        }
        attack.Play();
        
    }

    public void beaten()
    {
        demon.GetComponent<Animator>().Play("DemonDeath");
        PlayerController.canMove = true;
        alive = false;
    }
}
