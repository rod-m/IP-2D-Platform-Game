using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HealthPickup : MonoBehaviour
{
    public int healthBoost = 50;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            var _gameManager = GameObject.FindObjectOfType<GameManager>();
            _gameManager.AddHealth(healthBoost);
            //Destroy(this.gameObject);
            transform.gameObject.SetActive(false);
            Invoke("ReActivate", 60);
        }
    }

    void ReActivate()
    {
        transform.position = new Vector2(transform.position.x + Random.Range(-15 , 15), transform.position.y + 5);

        transform.gameObject.SetActive(true);
    }
}
