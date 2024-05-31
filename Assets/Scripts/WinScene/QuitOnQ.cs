using UnityEngine;

public class QuitOnQ : MonoBehaviour
{
    void Update()
    {
        // Check if the Q key is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Log a message for debugging purposes
            Debug.Log("Q key pressed. Quitting game...");

            // Quit the application
            QuitGame();
        }
    }

    void QuitGame()
    {
        // If running in the Unity editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If running as a standalone build
        Application.Quit();
#endif
    }
}
