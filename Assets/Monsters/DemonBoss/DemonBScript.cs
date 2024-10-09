using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject DemonBoss;

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
            QuizManager3.interaction = "demonb";
            QuizManager3.qcount = QuizManager3.qcount + 5;
            playerInRange = false;
        }
    }

    public void rightAnswer()
    {
        DemonBoss.GetComponent<Animator>().Play("DemonBTakeHit");
    }

    public void wrongAnswer()
    {
        DemonBoss.GetComponent<Animator>().Play("DemonBAttack");
        attack.Play();
    }

    public void beaten()
    {
        DemonBoss.GetComponent<Animator>().Play("DemonBDeath");
        PlayerController.canMove = true;
        alive = false;
        LightIntensity.newIntensity = 3.5f;
        StartCoroutine(deathroutine());
    }

    private IEnumerator deathroutine()
    {

        yield return new WaitForSecondsRealtime(1f);
        LightIntensity.newIntensity = 0f;
    }
}
