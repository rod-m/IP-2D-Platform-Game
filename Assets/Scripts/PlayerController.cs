using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Vector2 _scale;
    private int _direction = 1;
    
    public float speed = 5f;
    public float jumpForce = 10f;
    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool falling = false;
     //private GameManager _gameManager;

    private Vector3 startPosition;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _scale = transform.localScale;
        //_gameManager = GameObject.FindObjectOfType<GameManager>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        _animator.SetFloat("Speed", Mathf.Abs(move));
        SetDirection(move);
        SetMovement(move);
        Falling();
    }

    bool IsGrounded()
    {
        // If the ground point overlaps a collider on the Ground layer
        Collider2D col = Physics2D.OverlapCircle(groundPoint.position, 0.1f, whatIsGround);
        // if there is an overlapping collider then the character is grounded!
        return col != null;
    }
    void SetMovement(float move)
    {
        if (IsGrounded())
        {
            Vector2 newVelocity = _rigidbody2D.velocity;
            newVelocity.x = move * speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                newVelocity.y = jumpForce;
                _animator.SetTrigger("Jump");
                
            }
            _rigidbody2D.velocity = newVelocity;
        }
    }

    private void Falling()
    {
        if (_rigidbody2D.velocity.y < 0 && !IsGrounded())
        {
            falling = true;
            _animator.SetBool("Falling", true);
        }
        else if (falling)
        {
            falling = false;
            _animator.SetBool("Falling", false);
        }
    }

    void SetDirection(float move)
    {
        // if moving and direction has changed
        if (Mathf.RoundToInt(move) != 0 && Mathf.RoundToInt(move) != _direction)
        {
            // set new direction, note only want rounded values -1, 0, 1
            _direction = Mathf.RoundToInt(move);
            _scale.x *= -1; // toggle x scale only
            transform.localScale = _scale;
        }
    }

    public void ReSpawn()
    {
        transform.position = startPosition;
    }
 
}
