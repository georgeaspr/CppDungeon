using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text[] scores;
    void Start()
    {
        string level1file = Path.Combine(Application.persistentDataPath, "level1.txt");

        if (File.Exists(level1file))
        {
            string fileContents1 = File.ReadAllText(level1file);
            scores[0].text = "Score: " + fileContents1 +"/90";
            DoorLevelSelect2.phasKey = true;
            DoorLevelSelect1.phasKey = true;
        }
        else
        {
            Debug.Log("File does not exist: " + level1file);
            scores[0].text = "Score: --/90";
            DoorLevelSelect1.phasKey = true;
        }

        string level2file = Path.Combine(Application.persistentDataPath, "level2.txt");

        if (File.Exists(level2file))
        {
            string fileContents2 = File.ReadAllText(level2file);
            scores[1].text = "Score: " + fileContents2 + "/120";
            DoorLevelSelect3.phasKey = true;
            DoorLevelSelect2.phasKey = true;
        }
        else
        {
            Debug.Log("File does not exist: " + level2file);
            scores[1].text = "Score: --/120";
        }

        string level3file = Path.Combine(Application.persistentDataPath, "level3.txt");

        if (File.Exists(level3file))
        {
            string fileContents3 = File.ReadAllText(level3file);
            scores[2].text = "Score: " + fileContents3 +"/140";
            DoorLevelSelect3.phasKey = true;
        }
        else
        {
            Debug.Log("File does not exist: " + level3file);
            scores[2].text = "Score: --/140";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
