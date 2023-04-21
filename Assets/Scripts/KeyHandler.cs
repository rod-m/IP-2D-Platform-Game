using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandler : MonoBehaviour
{
    private Vector2 start;
    public Transform destination;
    public string keyName = "Key One";
    void Start()
    {
        start = transform.position;
    }
    public void ResetKey()
    {
        transform.position = start;
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        // add UI update to GM
        var gm = GameObject.FindObjectOfType<GameManager>();
        gm.FoundTeleportKey(this);
        // hide key
        gameObject.SetActive(false);
    }
}
