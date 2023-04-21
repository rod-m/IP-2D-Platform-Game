using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public enum EnemyState{Idle, Patrol, Attack, Die}
public class EnemyController : MonoBehaviour
{
    private EnemyState _enemyState = EnemyState.Idle;
    public Transform[] patrolPoints;
    private int currentPatrolpoint = 0;
    private float interpolation = 0f;
    public float speed = 0.5f;
    private Animator anim;
    public int health = 100;
    public GameObject EnemyParts;
    void Start()
    {
        anim = GetComponent<Animator>();
        EnemyParts.SetActive(false);
    }
    
    void Update()
    {
        switch (_enemyState)
        {
            case EnemyState.Idle:

                break;
            case EnemyState.Patrol:
                Patrol();
                break;
            case EnemyState.Attack:
                break;
            case EnemyState.Die:
                EnemyParts.transform.position = transform.position;
                EnemyParts.SetActive(true);
                Destroy(EnemyParts, 5f);
                Destroy(gameObject);
               break;
            default:
                break;
                
        }
    }

    void Patrol()
    {
        int numPos = patrolPoints.Length;
        Vector2 posA = patrolPoints[currentPatrolpoint % numPos].position;
        Vector2 posB = patrolPoints[(currentPatrolpoint + 1) % numPos].position;
        transform.position = Vector2.Lerp(
            posA,
            posB,
            interpolation);
        interpolation += speed * Time.deltaTime;
        if (interpolation >= 1.0f)
        {
            interpolation = 0;
            currentPatrolpoint++;
        }
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
        _enemyState = EnemyState.Patrol;
        anim.SetBool("Attacking", false);
    }

    public void Damage(int _damage)
    {
        health -= _damage;
        if (health <= 0)
        {
            _enemyState = EnemyState.Die;
        }
    }
}
