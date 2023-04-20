using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour
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
