using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpikes : MonoBehaviour
{
    static public float moveSpeed = 0f; // Adjust the speed as needed

    private Vector3 targetPosition;
    private bool isMoving = false;
    public GameObject moovingSpikes;

    void Start()
    {
        targetPosition = moovingSpikes.transform.position + new Vector3(0f, 2f, 0f);
        moveSpeed = 0f;
    }

    void Update()
    {
        if (isMoving)
        {
            // Move the moovingSpikes object towards the target position gradually
            moovingSpikes.transform.position = Vector3.Lerp(moovingSpikes.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if the object has reached close to the target position
            if (Vector3.Distance(moovingSpikes.transform.position, targetPosition) < 0.01f)
            {
                // Stop moving once close enough to the target position
                isMoving = false;
            }
        }
    }

    public void StartMoving()
    {
        isMoving = true;
        moveSpeed = 7f;
    }


}
