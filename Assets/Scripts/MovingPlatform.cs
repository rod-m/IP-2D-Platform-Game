using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform[] positions;

    private int currentWaypoint = 0;
    private float interpolation = 0;
    public float speed = 0.5f;
    // Start is called before the first frame update
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
        
        interpolation += speed * Time.deltaTime;
        platform.position = Vector2.Lerp(posA, posB, interpolation);
        if (interpolation >= 1f)
        {
            interpolation = 0;
            currentWaypoint++;
        }
    }

    
}
