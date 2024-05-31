using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject player;
    public GameObject ai;
    public AIPathRecorder aiPathRecorder;
    public AIPathFollower aiPathFollower;
    public float tutorialDelay = 10f;
    public float updateInterval = 0.5f; // Interval for updating path points

    void Start()
    {
        StartCoroutine(StartTutorial());
    }

    IEnumerator StartTutorial()
    {
        // Enable AI for path recording
        ai.SetActive(true);
        aiPathRecorder.enabled = true;

        // Wait for the initial delay
        yield return new WaitForSeconds(tutorialDelay);

        // Disable path recording and start following the path
        aiPathRecorder.enabled = false;
        aiPathFollower.enabled = true;

        // Continuously update path points
        StartCoroutine(UpdatePathPoints());
    }

    IEnumerator UpdatePathPoints()
    {
        while (true)
        {
            // Update path points with recorded points
            aiPathFollower.pathPoints = new List<Vector3>(aiPathRecorder.pathPoints);

            // Wait for the update interval
            yield return new WaitForSeconds(updateInterval);
        }
    }
}
