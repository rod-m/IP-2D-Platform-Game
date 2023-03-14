using System;
using UnityEngine;


    public class WillDamage : MonoBehaviour
    {
        private GameManager _gameManager;
        public int damage = 1;
        private void Start()
        {
            _gameManager = GameObject.FindObjectOfType<GameManager>();
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            Debug.Log($"Spike damage to {collision.collider.tag}");
            if(collision.collider.CompareTag("Player"))
            {
                _gameManager.AddHealth(-damage);
            }
        }
    }
