using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyState{Idle, Patrol, Attack, Die}
public class EnemyController : MonoBehaviour
{
    private EnemyState _enemyState = EnemyState.Idle;
    
    public Transform[] patrolPoints;
    private int _currentWaypoint = 0;
    private float _interpolation = 0;
    public float speed = 0.5f;
    
    private Animator anim;
    
    public GameObject EnemyParts;
    void Start()
    {
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && _enemyState != EnemyState.Die)
        {
            _enemyState = EnemyState.Attack;
            anim.SetBool("Attacking", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (_enemyState != EnemyState.Die)
        {
            _enemyState = EnemyState.Patrol;
            anim.SetBool("Attacking", false);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _enemyState = EnemyState.Die;
           
        }
    }
}
