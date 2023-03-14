using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int health = 100;
    public int score = 0;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public GameObject player;
    private void Start()
    {
        AddHealth(0);
        AddScore(0);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void PlayerHealthCheck()
    {
        if (health <= 0)
        {
            health = 100;
            player.SendMessage("ReSpawn");
        }
    }

    public void AddHealth(int s)
    {
        health += s;
        healthText.text = $"Health {health}";
        PlayerHealthCheck();
    } 
    public void AddScore(int h)
    {
        score += h;
        scoreText.text = $"Score {score}";
    }
}
