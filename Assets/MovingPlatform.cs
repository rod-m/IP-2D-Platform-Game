using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform[] positions;
    private int currentWaypoint = 0;
    private float interpolation = 0f;
    public float speed = 0.5f;
    
    void Start()
    {
        platform.position = positions[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        int numPos = positions.Length;
        Vector2 posA = positions[currentWaypoint % numPos].position;
        Vector2 posB = positions[(currentWaypoint + 1) % numPos].position;
        platform.position = Vector2.Lerp(
            posA,
            posB,
            interpolation);
        interpolation += speed * Time.deltaTime;
        if (interpolation >= 1.0f)
        {
            interpolation = 0;
            currentWaypoint++;
        }
    }
}
