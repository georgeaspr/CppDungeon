using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;

    public float speed = 2f;
    static public Vector3 targetPosition;
    static public Vector3 pPos;

    private void Start()
    {
        // Get the player's Rigidbody component
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        // Calculate the target position relative to the parent object
        Transform parentTransform = transform.parent;
        if (parentTransform != null)
        {
            targetPosition = parentTransform.position + new Vector3(41.418f, -5.98f, 0f);
            pPos = parentTransform.position;
        }
        else
        {
            targetPosition = new Vector3(41.418f, -5.98f, 0f);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.health = 0;
        }
    }

    private void Update()
    {

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }

    public void goBack()
    {
        targetPosition = pPos + new Vector3(41.418f, -5.98f, 0f);
    }

}
