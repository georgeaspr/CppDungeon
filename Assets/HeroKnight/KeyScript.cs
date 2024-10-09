using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private Rigidbody2D playerRigidbody; // Reference to the player's Rigidbody
    public GameObject key;
    public GameObject canvas;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DoorLevel1End.phasKey = true;
            Destroy(key);
            Spikes.targetPosition = new Vector3(72f, -5.98f, 0f) + Spikes.pPos;
            canvas.SetActive(true);
            QuizManager.interaction = "spikes";
            QuizManager.qcount = QuizManager.qcount + 2;
        }    
    }
}
