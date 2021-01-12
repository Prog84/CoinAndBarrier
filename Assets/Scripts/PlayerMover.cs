﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GroundDetection _groundDetection;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce = 10;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _rigidbody.velocity = Vector2.right * _speed;
        }
    }

    private void Jump()
    {
        if (_groundDetection.IsGrounded && Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
