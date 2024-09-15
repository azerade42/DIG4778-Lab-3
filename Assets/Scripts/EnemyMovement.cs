using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float distanceFromPlayer = 2f;
    [SerializeField] [Range(0,360)] float startingAngleDeg = 0f;
    float currentAngle = 0;
    [SerializeField] bool clockwise;

    void Start()
    {
        currentAngle = startingAngleDeg;
    }

    void Update()
    {
        int forwards = clockwise ? -1 : 1;
        // Rotate towards the player's position
        Vector3 relativePos = playerTransform.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(relativePos);
        transform.localRotation = newRotation;

        // Move in a circle
        currentAngle += Time.deltaTime * forwards;
        float x = distanceFromPlayer * Mathf.Cos(currentAngle);
        float y = distanceFromPlayer * Mathf.Sin(currentAngle);
        Vector3 currentPos = new Vector3(x, y, 0);
        transform.position = playerTransform.position + currentPos;

        // Reset angle when the circle is complete
        if (currentAngle >= 360f)
        {
            currentAngle -= 360f * forwards;
        }
    }
}
