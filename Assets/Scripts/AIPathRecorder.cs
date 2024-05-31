using UnityEngine;
using System.Collections.Generic;

public class AIPathRecorder : MonoBehaviour
{
    public List<Vector3> pathPoints = new List<Vector3>();
    public float recordInterval = 0.1f;
    private float recordTimer = 0f;

    void Update()
    {
        recordTimer += Time.deltaTime;
        if (recordTimer >= recordInterval)
        {
            pathPoints.Add(transform.position);
            recordTimer = 0f;
        }
    }
}
