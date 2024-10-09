using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorTrigger : MonoBehaviour
{
    public GameObject objectToAppear; // The object to appear when the player enters the trigger area
    public Sprite newDoorIcon; // The new icon for the door
    public AudioSource soundEffect; // The sound effect to play
    public string newSceneName; // The name of the new scene to load

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
            // Player is in range and pressed the SPACE button

            // Change door icon
            var doorSpriteRenderer = GetComponent<SpriteRenderer>();
            if (doorSpriteRenderer != null && newDoorIcon != null)
            {
                doorSpriteRenderer.sprite = newDoorIcon;
            }

            spacePressed = true;
            soundEffect.Play();

            
            PlayerController.canMove = false;


            // Start fade-out coroutine
            StartCoroutine(FadeOutAndLoadScene());
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
