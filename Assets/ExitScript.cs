using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Call the function to quit the game
                Application.Quit();
            }
    }   
  
}
