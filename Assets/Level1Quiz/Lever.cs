using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject objectToAppear; // The object to appear when the player enters the trigger area
    public GameObject movingObject;
    public GameObject canvas;
    public Sprite newLeverIcon; // The new icon for the lever

    private bool playerInRange; // Flag to track if the player is in range of the door
    private bool spacePressed = false;



    private Rigidbody2D playerRigidbody; // Reference to the player's Rigidbody
    
    private void Start()
    {
        // Get the player's Rigidbody component
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player has entered the trigger area
            objectToAppear.SetActive(true); // Make the object appear
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player has exited the trigger area
            objectToAppear.SetActive(false); // Make the object disappear
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space) && !spacePressed)
        {
            spacePressed = true;
            PlayerController.canMove = false;
            objectToAppear.SetActive(false);
            canvas.SetActive(true);
            QuizManager.interaction = "lever";
            QuizManager.qcount = QuizManager.qcount + 1;

        }
    }

    public void rightAnswer()
    {
        //canvas.SetActive(false);

        Vector3 newPosition = movingObject.transform.position;
        newPosition.y += 3f; // Adjust the value to control the distance of upward movement
        movingObject.transform.position = newPosition;

        //wrongPopUp.SetActive(false);
        PlayerController.canMove = true;

        var leverSpriteRenderer = GetComponent<SpriteRenderer>();
        if (leverSpriteRenderer != null && newLeverIcon != null)
        {
            leverSpriteRenderer.sprite = newLeverIcon;
        }
    }

    public void wrongAnswer()
    {
        PlayerController.health--;

    }
}
