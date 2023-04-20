using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idle,
    Patrol,
    Attack,
    Die
}

public class EnemyController : MonoBehaviour
{
    private EnemyState _enemyState = EnemyState.Idle;

    public Transform[] patrolPoints;
    private int _currentWaypoint = 0;
    private float _interpolation = 0;
    public float speed = 0.5f;
    
    private Animator anim;

    public GameObject EnemyParts;
    private GameManager _gameManager;
    public int health = 100;
    public int damage = 1;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();

        EnemyParts.SetActive(false);
        anim = GetComponent<Animator>();
        _enemyState = EnemyState.Patrol;
    }

    private void Update()
    {
        switch (_enemyState)
        {
            case EnemyState.Idle:
                //wait
                break;
            case EnemyState.Patrol:
                Patrol();
                break;
            case EnemyState.Attack:
                //attack
                break;
            case EnemyState.Die:
                //die
                EnemyParts.transform.position = transform.position;
                EnemyParts.SetActive(true);
                Destroy(EnemyParts, 5f);
                Destroy(gameObject);
                break;
        }
    }

    void Patrol()
    {
        int numPos = patrolPoints.Length;
        Vector2 posA = patrolPoints[_currentWaypoint % numPos].position;
        Vector2 posB = patrolPoints[(_currentWaypoint + 1) % numPos].position;

        _interpolation += speed * Time.deltaTime;
        transform.position = Vector2.Lerp(posA, posB, _interpolation);
        if (_interpolation >= 1f)
        {
            _interpolation = 0;
            _currentWaypoint++;
        }

        anim.SetFloat("Speed", speed);
    }

    public void AttackMode()
    {
        if (_enemyState != EnemyState.Die)
        {
            _enemyState = EnemyState.Attack;
            anim.SetBool("Attacking", true);
        }
    }

    public void PatrolMode()
    {
        if (_enemyState != EnemyState.Die)
        {
            _enemyState = EnemyState.Patrol;
            anim.SetBool("Attacking", false);
        }
    }

    public void Damage(int _damage)
    {
        health -= _damage;
        if (health <= 0)
        {
            _enemyState = EnemyState.Die;
            _gameManager.AddScore(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _gameManager.AddHealth(-damage);
        }
    }
}