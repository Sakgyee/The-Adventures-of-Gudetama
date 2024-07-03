using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgmManager : MonoBehaviour
{
    private static BgmManager instance;
    void Start()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set this instance as the singleton
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If another instance exists, destroy this one
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Check if the current scene is "BossCutScene"
        if (SceneManager.GetActiveScene().name == "BossCutScene"|| SceneManager.GetActiveScene().name == "MainMenu")
        {
            // Destroy the object if in "BossCutScene"
            Destroy(gameObject);
        }
    }
}
