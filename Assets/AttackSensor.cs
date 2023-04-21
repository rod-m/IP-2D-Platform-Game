using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackSensor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SendMessageUpwards("AttackMode");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        SendMessageUpwards("PatrolMode");
    }
}
