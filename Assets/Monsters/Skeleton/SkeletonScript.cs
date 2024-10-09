using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{
    public AudioSource soundEffect; // The sound effect to play
    public GameObject canvas;
    public GameObject skeleton;
    public AudioSource attack;

    private bool playerInRange; // Flag to track if the player is in range of the door
    private bool alive = true;


    private Rigidbody2D playerRigidbody; // Reference to the player's Rigidbody

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
            QuizManager.interaction = "skeleton";
            QuizManager.qcount = QuizManager.qcount + 3;
            playerInRange = false;
        }
    }

    public void rightAnswer()
    {
        skeleton.GetComponent<Animator>().Play("DamageSkeleton");
    }

    public void wrongAnswer()
    {
        skeleton.GetComponent<Animator>().Play("HitAnimation");
        attack.Play();
    }

    public void beaten()
    {
        skeleton.GetComponent<Animator>().Play("DeathSkeleton");
        PlayerController.canMove = true;
        alive = false;
    }
}
