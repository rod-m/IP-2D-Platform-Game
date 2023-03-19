using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandler : MonoBehaviour
{
    private Vector2 start;
    public Transform destination;
    public string keyName = "Teleport Key";
    private void Start()
    {
        start = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var _gameManager = GameObject.FindObjectOfType<GameManager>();
        _gameManager.FoundTeleportKey(this);
        this.gameObject.SetActive(false);
    }

    public void ResetKey()
    {
        this.transform.position = start;
        this.gameObject.SetActive(true);
    }
}
