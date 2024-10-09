using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorLevelSelect2 : MonoBehaviour
{
    public Sprite newDoorIcon; // The new icon for the door
    public AudioSource soundEffectOpen; // The sound effect to play
    public AudioSource soundEffectLock; // The sound effect to play when door is locked
    public string newSceneName; // The name of the new scene to load

    private bool playerInRange; // Flag to track if the player is in range of the door
    private bool spacePressed = false;
    static public bool phasKey = false;


    private Rigidbody2D playerRigidbody; // Reference to the player's Rigidbody

    private void Start()
    {
        // Get the player's Rigidbody component
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        phasKey = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player has entered the trigger area
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player has exited the trigger area
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space) && !spacePressed)
        {
            // Player is in range and pressed the SPACE button
            if (phasKey)
            {
                // Change door icon
                var doorSpriteRenderer = GetComponent<SpriteRenderer>();
                if (doorSpriteRenderer != null && newDoorIcon != null)
                {
                    doorSpriteRenderer.sprite = newDoorIcon;
                }

                spacePressed = true;
                soundEffectOpen.Play();


                PlayerController.canMove = false;


                // Start fade-out coroutine
                StartCoroutine(FadeOutAndLoadScene());
            }
            else
            {
                soundEffectLock.Play();
            }



        }
    }
    private IEnumerator FadeOutAndLoadScene()
    {
        // Perform fade-out effect here (e.g., using a screen overlay)

        yield return new WaitForSeconds(1f); // Adjust the duration of the fade-out effect as needed

        // Load the new scene
        if (!string.IsNullOrEmpty(newSceneName))
        {
            SceneManager.LoadScene(newSceneName);
        }
    }
}
