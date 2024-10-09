using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey2 : MonoBehaviour
{
    private Rigidbody2D playerRigidbody; // Reference to the player's Rigidbody
    public GameObject key;

    private void Start()
    {
        // Get the player's Rigidbody component
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DoorLevel2End.phasKey = true;
        }
        Destroy(key);
    }
}
