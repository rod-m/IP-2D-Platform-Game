using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
  public Transform destination;
  private Transform payload;
  private bool active = false;

  private void Update()
  {
    if (active && Input.GetKey(KeyCode.E))
    {
      var _gameManager = GameObject.FindObjectOfType<GameManager>();
      Vector2 keyDestination = _gameManager.UseTeleportKey();
      if (keyDestination != Vector2.zero)
      {
        payload.position = keyDestination;
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
