using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Book2Trigger : MonoBehaviour
{
    public GameObject objectToAppear; // The object to appear when the player enters the trigger area
    public AudioSource soundEffect; // The sound effect to play
    public GameObject Gobject;
    public Button FrontButton;
    public GameObject targetParent;

    private bool playerInRange; // Flag to track if the player is in range of the door
    private bool spacePressed = false;

    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public GameObject Page4;
    public GameObject Page5;
    public GameObject Page6;
    public GameObject Page7;
    public GameObject Page8;

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
            soundEffect.Play();


            PlayerController.canMove = false;

            Gobject.SetActive(true);

            for (int i = 0; i < targetParent.transform.childCount; i++)
            {
                GameObject child = targetParent.transform.GetChild(i).gameObject;
                child.SetActive(false);
            }
            Page1.SetActive(true);
            Page2.SetActive(true);
        }

        if (!Gobject.activeSelf && spacePressed)
        {
            PlayerController.canMove = true;
            spacePressed = false;
            Debug.Log("KANEI EXECUTE");
        }

    }

    public void frontbuttonPressed()
    {
        if (Page1.activeSelf)
        {
            Page1.SetActive(false);
            Page2.SetActive(false);
            Page3.SetActive(true);
            Page4.SetActive(true);
        }
        else if (Page3.activeSelf)
        {
            Page3.SetActive(false);
            Page4.SetActive(false);
            Page5.SetActive(true);
            Page6.SetActive(true);
        }
        else if (Page5.activeSelf)
        {
            Page5.SetActive(false);
            Page6.SetActive(false);
            Page7.SetActive(true);
            Page8.SetActive(true);
        }
        else if (Page7.activeSelf)
        {
            Page7.SetActive(false);
            Page8.SetActive(false);
            Page1.SetActive(true);
            Page2.SetActive(true);
        }
    }

    public void backbuttonPressed()
    {
        if (Page1.activeSelf)
        {
            Page1.SetActive(false);
            Page2.SetActive(false);
            Page7.SetActive(true);
            Page8.SetActive(true);
        }
        else if (Page3.activeSelf)
        {
            Page3.SetActive(false);
            Page4.SetActive(false);
            Page1.SetActive(true);
            Page2.SetActive(true);
        }
        else if (Page5.activeSelf)
        {
            Page5.SetActive(false);
            Page6.SetActive(false);
            Page3.SetActive(true);
            Page4.SetActive(true);
        }
        else if (Page7.activeSelf)
        {
            Page7.SetActive(false);
            Page8.SetActive(false);
            Page5.SetActive(true);
            Page6.SetActive(true);
        }
    }



}
