using UnityEngine;
using System.Collections;
using TMPro;

public class AIWIN : MonoBehaviour
{
    public Collider winCollider;
    public TextMeshProUGUI completionText;
    public string nextSceneName;

    private bool aiOnWinPart = false;
    private bool sceneLoadingStarted = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with " + other.name);

        // Check if the object has the tag "AI"
        if (other.CompareTag("AI"))
        {
            Debug.Log("AI entered the win part");
            aiOnWinPart = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit called with " + other.name);

        // Check if the object has the tag "AI"
        if (other.CompareTag("AI"))
        {
            Debug.Log("AI exited the win part");
            aiOnWinPart = false;
        }
    }

    void Update()
    {
        // Check if the AI is on the win part, the completion text is not set yet, and the scene loading has not started
        if (aiOnWinPart && completionText != null && completionText.text != "Good job!" && !sceneLoadingStarted)
        {
            Debug.Log("AI is on the win part and completion text is not set");

            // Set completion text
            completionText.text = "Good job!";

            // Load next scene after a delay
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        Debug.Log("Starting LoadNextScene coroutine");

        // Avoid starting the coroutine multiple times
        if (sceneLoadingStarted) yield break;

        sceneLoadingStarted = true;

        // Wait for a short delay
        yield return new WaitForSeconds(2f);

        // Check if the nextSceneName is not null or empty
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            Debug.Log("Loading next scene: " + nextSceneName);
            // Load next scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not set!");
        }
    }
}
