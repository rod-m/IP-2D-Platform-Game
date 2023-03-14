using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectable : MonoBehaviour
{
    public int scoreBoost = 10;
    private void OnTriggerEnter2D(Collider2D col)
    {
        var _gameManager = GameObject.FindObjectOfType<GameManager>();
        _gameManager.AddScore(scoreBoost);
        Destroy(this.gameObject);
    }
}
