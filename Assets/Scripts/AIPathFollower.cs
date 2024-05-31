using UnityEngine;
using System.Collections.Generic;

public class AIPathFollower : MonoBehaviour
{
    public List<Vector3> pathPoints = new List<Vector3>();
    public float speed = 5f;
    private int currentPointIndex = 0;

    void Update()
    {
        if (currentPointIndex < pathPoints.Count)
        {
            Vector3 targetPosition = pathPoints[currentPointIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentPointIndex++; // Move to the next point
            }
        }
    }
}
