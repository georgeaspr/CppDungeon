using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesGeneral : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.health = 0;
        }
    }
}
