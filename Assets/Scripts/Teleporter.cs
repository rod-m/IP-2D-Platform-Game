using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform destination;
    private Transform payload;
    private bool active = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active && Input.GetKeyDown(KeyCode.E))
        {
            var gm = GameObject.FindObjectOfType<GameManager>();
            Vector2 newPos = gm.UseTeleportKey();
            if (newPos != Vector2.zero)
            {
                payload.position = newPos;
            }
            else
            {
                payload.position = destination.position;
            }
            
            active = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        payload = col.transform;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        active = false;
        payload = null;
    }
}
